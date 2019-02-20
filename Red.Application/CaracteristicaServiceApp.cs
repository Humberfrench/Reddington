using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System;
using System.Collections.Generic;

namespace Red.Application
{
    public class CaracteristicaServiceApp : BaseServiceApp, ICaracteristicaServiceApp
    {

        private readonly ICaracteristicaService _service;

        public CaracteristicaServiceApp(ICaracteristicaService caracteristicaService)
        {
            _service = caracteristicaService;
        }

        public ValidationResult Gravar(CaracteristicaViewModel caracteristica)
        {
            var caracteristicaSalvar = Mapper.Map<Caracteristica>(caracteristica);
            return _service.Gravar(caracteristicaSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public CaracteristicaViewModel ObterPorId(int id)
        {
            var caracteristica = _service.ObterPorId(id);
            return Mapper.Map<CaracteristicaViewModel>(caracteristica);
        }

        public IEnumerable<CaracteristicaViewModel> ObterTodos()
        {
            var caracteristica = _service.ObterTodos();
            return Mapper.Map<IEnumerable<CaracteristicaViewModel>>(caracteristica);
        }

        public IEnumerable<CaracteristicaViewModel> Filtrar(string nome)
        {
            var caracteristica = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<CaracteristicaViewModel>>(caracteristica);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
