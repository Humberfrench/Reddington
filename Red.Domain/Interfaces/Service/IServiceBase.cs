using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.DomainValidation;

namespace Red.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity>
      where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate);
    }
}