using System.Collections.Generic;
using Red.Domain.Entities;
using Red.DomainValidation;


namespace Red.Domain.Interfaces.Service
{
    public interface IEvangelizadorService : IServiceBase<Evangelizador>
    {
        IEnumerable<Evangelizador> Filtrar(string nome);
        ValidationResult Gravar(Evangelizador entity);
        ValidationResult Excluir(int id);
    }
}