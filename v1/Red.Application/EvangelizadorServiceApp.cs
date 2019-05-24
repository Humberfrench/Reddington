using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System;
using System.Collections.Generic;

namespace Red.Application
{
    public class EvangelizadorServiceApp : BaseServiceApp, IEvangelizadorServiceApp
    {

        private readonly IEvangelizadorService _service;

        public EvangelizadorServiceApp(IEvangelizadorService evangelizadorService)
        {
            _service = evangelizadorService;
        }

        public ValidationResult Gravar(EvangelizadorViewModel evangelizador)
        {
            var evangelizadorSalvar = Mapper.Map<Evangelizador>(evangelizador);
            return _service.Gravar(evangelizadorSalvar);
        }


        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public EvangelizadorViewModel ObterPorId(int id)
        {
            var evangelizador = _service.ObterPorId(id);
            return Mapper.Map<EvangelizadorViewModel>(evangelizador);
        }

        public IEnumerable<EvangelizadorViewModel> ObterTodos()
        {
            var evangelizador = _service.ObterTodos();
            return Mapper.Map<IEnumerable<EvangelizadorViewModel>>(evangelizador);
        }

        public IEnumerable<EvangelizadorViewModel> Filtrar(string nome)
        {
            var evangelizador = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<EvangelizadorViewModel>>(evangelizador);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
