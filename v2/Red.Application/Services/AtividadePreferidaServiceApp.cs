using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class AtividadePreferidaServiceApp : BaseServiceApp, IAtividadePreferidaServiceApp
    {
        private readonly IAtividadesPreferidasService atividadePreferidaService;

        public AtividadePreferidaServiceApp(IAtividadesPreferidasService atividadePreferidaService, IUnitOfWork uow) : base(uow)
        {
            this.atividadePreferidaService = atividadePreferidaService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

