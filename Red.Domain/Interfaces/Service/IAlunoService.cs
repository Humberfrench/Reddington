using Red.Domain.Entities;
using Red.DomainValidation;
using System.Collections.Generic;

namespace Red.Domain.Interfaces.Service
{
    public interface IAlunoService : IServiceBase<Aluno>
    {
        IEnumerable<Aluno> Filtrar(string nome);
        IEnumerable<Aluno> ObterTodosAtivos();
        IEnumerable<Aluno> ObterTodosNaoAtivos();
        ValidationResult Gravar(Aluno entity);
        ValidationResult Excluir(int id);
    }
}