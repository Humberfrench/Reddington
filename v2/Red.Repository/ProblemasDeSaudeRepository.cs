using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class ProblemasDeSaudeRepository : RepositorioBase<ProblemasDeSaude>, IProblemasDeSaudeRepository
    {
        public ProblemasDeSaudeRepository(IContextManager contextManager) : base(contextManager)
        {
        }

    }
}
