using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Expressions;
using Red.Domain.Interfaces;

namespace Red.Repository.UnityOfWork
{
    public class Repository<T> : IRepository<T> where T : IEntidade
    {
        private readonly UnityOfWork _unitOfWork;
        public Repository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = (UnityOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }
        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().Where(predicate);
        }

    }
}
