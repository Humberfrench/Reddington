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
    public class EvangelizadorService : ServiceBase<Evangelizador>, IEvangelizadorService
    {
        private readonly IEvangelizadorRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

       
        public EvangelizadorService(IEvangelizadorRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Evangelizador> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Evangelizador item)
        {
            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                var evangelizador = ObterPorId(item.Codigo);

                evangelizador.Contato = item.Contato;
                evangelizador.Email = item.Email;
                evangelizador.Nome = item.Nome;

                Atualizar(evangelizador);
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
