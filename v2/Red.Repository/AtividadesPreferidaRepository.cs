using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class AtividadesPreferidasRepository : RepositorioBase<AtividadesPreferidas>, IAtividadesPreferidasRepository
    {
        public AtividadesPreferidasRepository(IContextManager contextManager) : base(contextManager)
        {
        }

    }
}
