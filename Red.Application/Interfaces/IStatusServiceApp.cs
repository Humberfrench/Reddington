using System.Collections.Generic;
using Red.Application.ViewModel;
using Red.DomainValidation;

namespace Red.Application.Interfaces
{
    public interface IStatusServiceApp : IServiceBase<StatusViewModel>
    {
        IEnumerable<StatusViewModel> Filtrar(string nome);
        ValidationResult Gravar(StatusViewModel entity);
        ValidationResult Excluir(int id);
    }
}