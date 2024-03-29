﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Service;
using Red.DomainValidation;

namespace Red.Domain.Service
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Adicionar(TEntity obj)
        {
            _repository.Adicionar(obj);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public void Dispose()
        {
        //    _repository.Dispose();
        }

        public IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Pesquisar(predicate);
        }

    }
}
