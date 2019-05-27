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
    public class CaracteristicaServiceApp : BaseServiceApp, ICaracteristicaServiceApp
    {

        private readonly ICaracteristicaService caracteristicaService;

        public CaracteristicaServiceApp(ICaracteristicaService caracteristicaService, IUnitOfWork uow) : base(uow)
        {
            this.caracteristicaService = caracteristicaService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
