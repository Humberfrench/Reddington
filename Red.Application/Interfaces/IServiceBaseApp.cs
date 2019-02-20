using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.DomainValidation;

namespace Red.Application.Interfaces
{
    public interface IServiceBase<TEntity>
      where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
    }
}