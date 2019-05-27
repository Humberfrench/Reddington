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
    public class StatusServiceApp : BaseServiceApp, IStatusServiceApp
    {

        private readonly IStatusService statusService;

        public StatusServiceApp(IStatusService statusService, IUnitOfWork uow) : base(uow)
        {
            this.statusService = statusService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
