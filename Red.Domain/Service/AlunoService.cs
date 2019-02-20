using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System.Collections.Generic;
using System.Linq;

namespace Red.Domain.Service
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository repository;
        private readonly IStatusRepository statusRepository;
        private readonly IResponsavelRepository responsavelRepository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public AlunoService(IAlunoRepository repository,
                            IStatusRepository statusRepository,
                            IResponsavelRepository responsavelRepository)
            : base(repository)
        {
            this.repository = repository;
            this.statusRepository = statusRepository;
            this.responsavelRepository = responsavelRepository;
        }

        public IEnumerable<Aluno> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public IEnumerable<Aluno> ObterTodosAtivos()
        {
            var registros = Pesquisar(p => p.Matriculado).ToList();
            return registros;
        }
        public IEnumerable<Aluno> ObterTodosNaoAtivos()
        {
            var registros = Pesquisar(p => !p.Matriculado).ToList();
            return registros;
        }
        public ValidationResult Gravar(Aluno item)
        {
            item.Status = statusRepository.ObterPorId(item.Status.Codigo);
            item.Responsavel = responsavelRepository.ObterPorId(item.Responsavel.Codigo);

            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                Atualizar(item);
            }

            return validationResult;
        }


        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add("Registro não encontrado");
                return validationResult;
            }
            //Verificações

            if (item.Turmas.Any())
            // Não pode
            {
                validationResult.Add("Não é possível Excluir aluno vinculado a Turmas atuais ou passadas");
                return validationResult;
            }

            repository.Excluir(item);

            return validationResult;

        }

    }
}
