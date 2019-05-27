using System.Collections.Generic;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Domain.ObjectValue;
using Red.Repository.Base;
using Red.Repository.Interface;

namespace Red.Repository
{
    public class TurmaRepository : RepositorioBase<Turma>, ITurmaRepository
    {
        public TurmaRepository(IContextManager contextManager) : base(contextManager)
        {

        }

    }
}
