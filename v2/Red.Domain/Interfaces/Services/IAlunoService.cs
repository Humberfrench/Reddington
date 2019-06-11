using French.Tools.DomainValidator;
using Red.Domain.Entity;

namespace Red.Domain.Interfaces.Services
{
    public interface IAlunoService : IServiceBase<Aluno>
    {
        ValidationResult Excluir(int id);
        ValidationResult Gravar(Aluno entity);

    }
}