using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class ResponsavelRepository : RepositorioBase<Responsavel>, IResponsavelRepository
    {
        public ResponsavelRepository(IContextManager contextManager) : base(contextManager)
        {
        }
    }
}
