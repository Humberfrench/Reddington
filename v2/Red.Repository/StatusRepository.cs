using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class StatusRepository : RepositorioBase<Status>, IStatusRepository
    {
        public StatusRepository(IContextManager contextManager) : base(contextManager)
        {
        }

    }
}
