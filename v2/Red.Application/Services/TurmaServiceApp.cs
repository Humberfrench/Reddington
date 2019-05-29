using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class TurmaServiceApp : BaseServiceApp, ITurmaServiceApp
    {

        private readonly ITurmaService turmaService;

        public TurmaServiceApp(ITurmaService turmaService, IUnitOfWork uow) : base(uow)
        {
            this.turmaService = turmaService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<TurmaViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public TurmaViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Gravar(TurmaViewModel item)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
