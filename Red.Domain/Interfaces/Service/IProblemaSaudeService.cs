using System.Collections.Generic;
using Red.Domain.Entities;
using Red.DomainValidation;


namespace Red.Domain.Interfaces.Service
{
    public interface IProblemaSaudeService : IServiceBase<ProblemaSaude>
    {
        IEnumerable<ProblemaSaude> Filtrar(string nome);
        ValidationResult Gravar(ProblemaSaude entity);
        ValidationResult Excluir(int id);
    }
}