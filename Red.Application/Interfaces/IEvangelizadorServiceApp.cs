using System.Collections.Generic;
using Red.Application.ViewModel;
using Red.DomainValidation;

namespace Red.Application.Interfaces
{
    public interface IEvangelizadorServiceApp : IServiceBase<EvangelizadorViewModel>
    {
        IEnumerable<EvangelizadorViewModel> Filtrar(string nome);
        ValidationResult Gravar(EvangelizadorViewModel entity);
        ValidationResult Excluir(int id);
    }
}