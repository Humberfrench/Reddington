using Red.Application.ViewModel;
using Red.Application.ViewModel.DTO;
using Red.DomainValidation;
using System.Collections.Generic;

namespace Red.Application.Interfaces
{
    public interface ITurmaServiceApp : IServiceBase<TurmaViewModel>
    {
        IEnumerable<TurmaViewModel> Filtrar(string nome);
        ValidationResult Gravar(string nome, int ano, int evangelizador);
        ValidationResult Atualizar(int turma, string nome);
        ValidationResult Excluir(int id);
        ValidationResult ExcluirAluno(int idTurma, int idAluno);
        ValidationResult AdicionarAlunos(int idTurma, string idAlunos);
        IEnumerable<EvangelizadorAlunoViewModel> ObterPorEvangelizador(int evangelizador, int ano);
        IEnumerable<EvangelizadorAlunoViewModel> ObterTodosPorEvangelizador(int evangelizador, int ano);
        IEnumerable<AlunosViewModel> ObterAlunosLivres(int ano);
        TurmaViewModel ObterTurma(int idEvangelizador, int ano);
        ValidationResult CopiarTurma(int idTurma, int ano, string nome);
    }
}