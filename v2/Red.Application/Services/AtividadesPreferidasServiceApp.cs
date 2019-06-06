using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class AtividadesPreferidasServiceApp : BaseServiceApp, IAtividadesPreferidasServiceApp
    {
        private readonly IAtividadesPreferidasService atividadePreferidaService;

        public AtividadesPreferidasServiceApp(IAtividadesPreferidasService atividadePreferidaService, IUnitOfWork uow) : base(uow)
        {
            this.atividadePreferidaService = atividadePreferidaService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<AtividadesPreferidasViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public AtividadesPreferidasViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Gravar(AtividadesPreferidasViewModel item)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}

