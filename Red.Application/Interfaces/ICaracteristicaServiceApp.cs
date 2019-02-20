using System.Collections.Generic;
using Red.Application.ViewModel;
using Red.DomainValidation;

namespace Red.Application.Interfaces
{
    public interface ICaracteristicaServiceApp : IServiceBase<CaracteristicaViewModel>
    {
        IEnumerable<CaracteristicaViewModel> Filtrar(string nome);
        ValidationResult Gravar(CaracteristicaViewModel entity);
        ValidationResult Excluir(int id);
    }
}