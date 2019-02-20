using System.Collections.Generic;
using Red.Application.ViewModel;
using Red.DomainValidation;

namespace Red.Application.Interfaces
{
    public interface IResponsavelServiceApp : IServiceBase<ResponsavelViewModel>
    {
        IEnumerable<ResponsavelViewModel> Filtrar(string nome);
        ValidationResult Gravar(ResponsavelViewModel entity);
        ValidationResult Excluir(int id);
    }
}