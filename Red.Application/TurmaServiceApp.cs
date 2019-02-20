using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Application.ViewModel.DTO;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;
using System;
using System.Collections.Generic;

namespace Red.Application
{
    public class TurmaServiceApp : BaseServiceApp, ITurmaServiceApp
    {

        private readonly ITurmaService _service;
        //readonly IMapper Mapper;

        public TurmaServiceApp(ITurmaService turmaService)
        {
            _service = turmaService;
        }

        public ValidationResult Gravar(string nome, int ano, int evangelizador)
        {
            return _service.Gravar(nome, ano, evangelizador);
        }

        public ValidationResult Atualizar(int turma, string nome)
        {
            return _service.Atualizar(turma, nome);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public ValidationResult ExcluirAluno(int idTurma, int idAluno)
        {
            return _service.ExcluirAluno(idTurma, idAluno);
        }

        public ValidationResult AdicionarAlunos(int idTurma, string idAlunos)
        {
            return _service.AdicionarAlunos(idTurma, idAlunos);
        }

        public TurmaViewModel ObterPorId(int id)
        {
            var turma = _service.ObterPorId(id);
            return Mapper.Map<TurmaViewModel>(turma);
        }

        public IEnumerable<TurmaViewModel> ObterTodos()
        {
            var turma = _service.ObterTodos();
            return Mapper.Map<IEnumerable<TurmaViewModel>>(turma);
        }

        public IEnumerable<TurmaViewModel> Filtrar(string nome)
        {
            var turma = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<TurmaViewModel>>(turma);
        }

        public IEnumerable<EvangelizadorAlunoViewModel> ObterPorEvangelizador(int evangelizador, int ano)
        {
            var turma = _service.ObterPorEvangelizador(evangelizador, ano);
            return Mapper.Map<IEnumerable<EvangelizadorAlunoViewModel>>(turma);
        }

        public IEnumerable<EvangelizadorAlunoViewModel> ObterTodosPorEvangelizador(int evangelizador, int ano)
        {
            var turma = _service.ObterTodosPorEvangelizador(evangelizador, ano);
            return Mapper.Map<IEnumerable<EvangelizadorAlunoViewModel>>(turma);
        }

        public IEnumerable<AlunosViewModel> ObterAlunosLivres(int ano)
        {
            var turma = _service.ObterAlunosLivres(ano);
            return Mapper.Map<IEnumerable<AlunosViewModel>>(turma);
        }

        public TurmaViewModel ObterTurma(int idEvangelizador, int ano)
        {

            var turma = _service.ObterTurma(idEvangelizador, ano);
            return Mapper.Map<TurmaViewModel>(turma);

        }
        public ValidationResult CopiarTurma(int idTurma, int ano, string nome)

        {

            return _service.CopiarTurma(idTurma, ano, nome);

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
