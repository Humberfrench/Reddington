using System.Linq;
using Red.Domain.Interfaces;

namespace Red.Repository.UnityOfWork
{
    public interface IRepository<T> where T : IEntidade
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
