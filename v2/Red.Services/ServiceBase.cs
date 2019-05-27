using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Services;

namespace Red.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Adicionar(TEntity obj)
        {
            repository.Adicionar(obj);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return repository.ObterTodos();
        }

        public TEntity ObterPorId(int id)
        {
            return repository.ObterPorId(id);
        }

        public void Atualizar(TEntity obj)
        {
            repository.Atualizar(obj);
        }

        public void Dispose()
        {
            //    _repository.Dispose();
        }

        public IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.Pesquisar(predicate);
        }
    }
}