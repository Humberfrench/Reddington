using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class AlunoServiceApp : BaseServiceApp, IAlunoServiceApp
    {
        private readonly IAlunoService alunoService;

        public AlunoServiceApp(IAlunoService alunoService, IUnitOfWork uow) : base(uow)
        {
            this.alunoService = alunoService;
        }

        public IList<AlunoViewModel> ObterTodos()
        {
            var dados = alunoService.ObterTodos();

            var retorno = Mapper.Map<IList<AlunoViewModel>>(dados);

            return retorno;
        }
        public AlunoViewModel ObterPorId(int id)
        {
            var dados = alunoService.ObterPorId(id);

            var retorno = Mapper.Map<AlunoViewModel>(dados);

            return retorno;
        }

        public ValidationResult Gravar(AlunoViewModel item)
        {
            var entity = Mapper.Map<Aluno>(item);

            var retorno = alunoService.Gravar(entity);

            if(retorno.IsValid)
            {
                Commit();
                if(!ValidationResult.IsValid)
                {
                    return ValidationResult;
                }
            }
            return retorno;

        }

        public ValidationResult Excluir(int id)
        {
            var retorno = alunoService.Excluir(id);
            if (retorno.IsValid)
            {
                Commit();
                if (!ValidationResult.IsValid)
                {
                    return ValidationResult;
                }
            }
            return retorno;

        }

        public List<AlunoViewModel> ObterTodosPorStatus(int statusId)
        {
            var dados = alunoService.ObterTodosPorStatus(statusId);

            var retorno = Mapper.Map<List<AlunoViewModel>>(dados);

            return retorno;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

