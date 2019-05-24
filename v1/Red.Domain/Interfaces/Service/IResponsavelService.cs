using System.Collections.Generic;
using Red.Domain.Entities;
using Red.DomainValidation;

namespace Red.Domain.Interfaces.Service
{
    public interface IResponsavelService : IServiceBase<Responsavel>
    {
        IEnumerable<Responsavel> Filtrar(string nome);
        ValidationResult Gravar(Responsavel entity);
        ValidationResult Excluir(int id);
    }
}