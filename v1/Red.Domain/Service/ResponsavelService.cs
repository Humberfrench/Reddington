using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Service;
using Red.Domain.Service;
using Red.DomainValidation;

namespace Red.Domain.Service
{
    public class ResponsavelService : ServiceBase<Responsavel>, IResponsavelService
    {
        private readonly IResponsavelRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public ResponsavelService(IResponsavelRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Responsavel> Filtrar(string nome)
        {
            var registros = Pesquisar(p => (p.Responsavel1 == nome)||
                                           (p.Responsavel2 == nome)).ToList();
            return registros;
        }

        public ValidationResult Gravar(Responsavel item)
        {
            
            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                var responsavel = ObterPorId(item.Codigo);
                responsavel.Alunos.ToList().ForEach(aluno => item.Alunos.Add(aluno));
                Atualizar(item);
            }

            return validationResult;
        }


        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            repository.Excluir(item);

            return validationResult;

        }


    }
}
