using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.Domain.Interfaces;

namespace Red.Repository.UnityOfWork
{
    public interface IUnityOfWork
    {
        void BeginTransaction();
        void Commit();
        void Salvar(IEntidade entidade);
        void Excluir(IEntidade entidade);
    }
}
