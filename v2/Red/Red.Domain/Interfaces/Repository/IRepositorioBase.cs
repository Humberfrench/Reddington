using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Red.Domain.Interfaces.Repository
{
    public interface IRepositorioBase<TEntidade> : IDisposable where TEntidade : class
    {
        void Adicionar(TEntidade obj);

        void Atualizar(TEntidade obj);

        void Remover(TEntidade obj);

        TEntidade ObterPorId(int id);

        IEnumerable<TEntidade> ObterTodos();

        IEnumerable<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> predicate);
    }
}