using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System;
using System.Collections.Generic;

namespace Red.Application
{
    public class AlunoServiceApp : BaseServiceApp, IAlunoServiceApp
    {
        private readonly IAlunoService _service;

        public AlunoServiceApp(IAlunoService alunoService)
        {
            _service = alunoService;
        }

        public ValidationResult Gravar(AlunoViewModel aluno)
        {
            var alunoSalvar = Mapper.Map<AlunoViewModel, Aluno>(aluno);
            return _service.Gravar(alunoSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public AlunoViewModel ObterPorId(int id)
        {
            var aluno = _service.ObterPorId(id);
            return Mapper.Map<Aluno, AlunoViewModel>(aluno);
        }

        public IEnumerable<AlunoViewModel> ObterTodos()
        {
            var aluno = _service.ObterTodos();
            var alunoVm = Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(aluno);
            return alunoVm;
        }

        public IEnumerable<AlunoViewModel> ObterTodosAtivos()
        {
            var aluno = _service.ObterTodosAtivos();
            var alunoVm = Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(aluno);
            return alunoVm;
        }


        public IEnumerable<AlunoViewModel> ObterTodosNaoAtivos()
        {
            var aluno = _service.ObterTodosNaoAtivos();
            var alunoVm = Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(aluno);
            return alunoVm;
        }
        public IEnumerable<AlunoViewModel> Filtrar(string nome)
        {
            var aluno = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<AlunoViewModel>>(aluno);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

