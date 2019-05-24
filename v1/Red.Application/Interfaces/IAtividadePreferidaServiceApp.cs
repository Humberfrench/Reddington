using System.Collections.Generic;
using Red.Application.ViewModel;
using Red.DomainValidation;

namespace Red.Application.Interfaces
{
    public interface IAtividadePreferidaServiceApp : IServiceBase<AtividadePreferidaViewModel>
    {
        IEnumerable<AtividadePreferidaViewModel> Filtrar(string nome);
        ValidationResult Gravar(AtividadePreferidaViewModel entity);
        ValidationResult Excluir(int id);
    }
}