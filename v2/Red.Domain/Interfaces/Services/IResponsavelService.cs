using French.Tools.DomainValidator;
using Red.Domain.Entity;

namespace Red.Domain.Interfaces.Services
{
    public interface IResponsavelService : IServiceBase<Responsavel>
    {
        ValidationResult Excluir(int id);
        ValidationResult Gravar(Responsavel entity);

    }
}