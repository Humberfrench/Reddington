using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System;
using System.Collections.Generic;

namespace Red.Application
{
    public class ResponsavelServiceApp : BaseServiceApp, IResponsavelServiceApp
    {

        private readonly IResponsavelService _service;

        public ResponsavelServiceApp(IResponsavelService responsavelService)
        {
            _service = responsavelService;
        }

        public ValidationResult Gravar(ResponsavelViewModel responsavel)
        {
            var responsavelSalvar = Mapper.Map<Responsavel>(responsavel);
            return _service.Gravar(responsavelSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public ResponsavelViewModel ObterPorId(int id)
        {
            var responsavel = _service.ObterPorId(id);
            return Mapper.Map<ResponsavelViewModel>(responsavel);
        }

        public IEnumerable<ResponsavelViewModel> ObterTodos()
        {
            var responsavel = _service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<ResponsavelViewModel>>(responsavel);
            return retorno;
        }

        public IEnumerable<ResponsavelViewModel> Filtrar(string nome)
        {
            var responsavel = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<ResponsavelViewModel>>(responsavel);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
