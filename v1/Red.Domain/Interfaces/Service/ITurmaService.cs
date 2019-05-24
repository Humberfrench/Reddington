using Red.Domain.Entities;
using Red.Domain.ObjectValue;
using Red.DomainValidation;
using System.Collections.Generic;

namespace Red.Domain.Interfaces.Service
{
    public interface ITurmaService : IServiceBase<Turma>
    {
        IEnumerable<Turma> Filtrar(string nome);
        ValidationResult Gravar(string nome, int ano, int evangelizador);
        ValidationResult Atualizar(int turma, string nome);
        ValidationResult Excluir(int id);
        ValidationResult ExcluirAluno(int idTurma, int idAluno);
        ValidationResult AdicionarAlunos(int idTurma, string idAlunos);
        IEnumerable<EvangelizadorAluno> ObterPorEvangelizador(int evangelizador, int ano);
        IEnumerable<EvangelizadorAluno> ObterTodosPorEvangelizador(int evangelizador, int ano);
        IEnumerable<Alunos> ObterAlunosLivres(int ano);
        Turma ObterTurma(int idEvangelizador, int ano);
        ValidationResult CopiarTurma(int idTurma, int ano, string nome);
    }
}