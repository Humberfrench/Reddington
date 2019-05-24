using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System;
using System.Collections.Generic;

namespace Red.Application
{
    public class AtividadePreferidaServiceApp : BaseServiceApp, IAtividadePreferidaServiceApp
    {
        private readonly IAtividadePreferidaService _service;

        public AtividadePreferidaServiceApp(IAtividadePreferidaService atividadePreferidaService)
        {
            _service = atividadePreferidaService;
        }

        public ValidationResult Gravar(AtividadePreferidaViewModel atividadePreferida)
        {
            var atividadePreferidaSalvar = Mapper.Map<AtividadePreferida>(atividadePreferida);
            return _service.Gravar(atividadePreferidaSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public AtividadePreferidaViewModel ObterPorId(int id)
        {
            var atividadePreferida = _service.ObterPorId(id);
            return Mapper.Map<AtividadePreferidaViewModel>(atividadePreferida);
        }

        public IEnumerable<AtividadePreferidaViewModel> ObterTodos()
        {
            var atividadePreferida = _service.ObterTodos();
            return Mapper.Map<IEnumerable<AtividadePreferidaViewModel>>(atividadePreferida);
        }

        public IEnumerable<AtividadePreferidaViewModel> Filtrar(string nome)
        {
            var atividade = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<AtividadePreferidaViewModel>>(atividade);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

