using Red.Domain.ObjectValue;
using System.Collections.Generic;
using Red.Domain.Entity;

namespace Red.Domain.Interfaces.Repository
{
    public interface ITurmaRepository : IRepositoryBase<Turma>
    {
        IEnumerable<EvangelizadorAluno> ObterPorEvangelizador(int evangelizador, int ano);
        IEnumerable<EvangelizadorAluno> ObterTodosPorEvangelizador(int evangelizador, int ano);
        IEnumerable<Alunos> ObterAlunosLivres(int ano);
    }
}