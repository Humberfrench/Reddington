using System.Collections.Generic;
using Red.Domain.Entities;
using Red.DomainValidation;


namespace Red.Domain.Interfaces.Service
{
    public interface IAtividadePreferidaService : IServiceBase<AtividadePreferida>
    {
        IEnumerable<AtividadePreferida> Filtrar(string nome);
        ValidationResult Gravar(AtividadePreferida entity);
        ValidationResult Excluir(int id);
    }
}