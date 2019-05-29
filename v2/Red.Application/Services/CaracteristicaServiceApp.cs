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

        public IList<CaracteristicaViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public CaracteristicaViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Gravar(CaracteristicaViewModel item)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
