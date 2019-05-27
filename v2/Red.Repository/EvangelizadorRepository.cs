using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class EvangelizadorRepository : RepositorioBase<Evangelizador>, IEvangelizadorRepository
    {
        public EvangelizadorRepository(IContextManager contextManager) : base(contextManager)
        {
        }
    }
}
