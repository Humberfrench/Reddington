using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System;
using System.Collections.Generic;

namespace Red.Application
{
    public class ProblemaSaudeServiceApp : BaseServiceApp, IProblemaSaudeServiceApp
    {

        private readonly IProblemaSaudeService _service;

        public ProblemaSaudeServiceApp(IProblemaSaudeService problemaSaudeService)
        {
            _service = problemaSaudeService;
        }

        public ValidationResult Gravar(ProblemaSaudeViewModel problemaSaude)
        {
            var problemaSaudeSalvar = Mapper.Map<ProblemaSaude>(problemaSaude);
            return _service.Gravar(problemaSaudeSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public ProblemaSaudeViewModel ObterPorId(int id)
        {
            var problemaSaude = _service.ObterPorId(id);
            return Mapper.Map<ProblemaSaudeViewModel>(problemaSaude);
        }

        public IEnumerable<ProblemaSaudeViewModel> ObterTodos()
        {
            var problemaSaude = _service.ObterTodos();
            return Mapper.Map<IEnumerable<ProblemaSaudeViewModel>>(problemaSaude);
        }

        public IEnumerable<ProblemaSaudeViewModel> Filtrar(string nome)
        {
            var problema = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<ProblemaSaudeViewModel>>(problema);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
