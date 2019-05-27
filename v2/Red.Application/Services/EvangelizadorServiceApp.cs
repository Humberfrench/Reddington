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
    public class EvangelizadorServiceApp : BaseServiceApp, IEvangelizadorServiceApp
    {

        private readonly IEvangelizadorService evangelizadorService;

        public EvangelizadorServiceApp(IEvangelizadorService evangelizadorService, IUnitOfWork uow) : base(uow)
        {
            this.evangelizadorService = evangelizadorService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
