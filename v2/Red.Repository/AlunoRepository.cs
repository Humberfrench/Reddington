using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Base;
using Red.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;

namespace Red.Repository
{
    public class AlunoRepository : RepositorioBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public override IEnumerable<Aluno> ObterTodos()
        {
            return DbSet.Include(r => r.Responsavel).Include(s => s.Status);
        }
    }
}
