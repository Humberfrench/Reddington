using System.Collections.Generic;
using Red.Domain.Entities;
using Red.DomainValidation;

namespace Red.Domain.Interfaces.Service
{
    public interface IStatusService : IServiceBase<Status>
    {
        IEnumerable<Status> Filtrar(string nome);
        ValidationResult Gravar(Status entity);
        ValidationResult Excluir(int id);
    }
}