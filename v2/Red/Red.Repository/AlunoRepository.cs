using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class AlunoRepository : RepositorioBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IContextManager contextManager) : base(contextManager)
        {
        }
    }
}
