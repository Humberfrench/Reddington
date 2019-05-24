using System.Collections.Generic;
using Red.Domain.Entities;
using Red.DomainValidation;


namespace Red.Domain.Interfaces.Service
{
    public interface ICaracteristicaService : IServiceBase<Caracteristica>
    {
        IEnumerable<Caracteristica> Filtrar(string nome);
        ValidationResult Gravar(Caracteristica entity);
        ValidationResult Excluir(int id);
    }
}