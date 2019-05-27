using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class CaracteristicaRepository : RepositorioBase<Caracteristica>, ICaracteristicaRepository
    {
        public CaracteristicaRepository(IContextManager contextManager) : base(contextManager)
        {
        }

    }
}
