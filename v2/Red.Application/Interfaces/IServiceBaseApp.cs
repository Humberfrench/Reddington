using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using French.Tools.DomainValidator;

namespace Red.Application.Interfaces
{
    public interface IServiceBaseApp<T>
    {
        void BeginTransaction();

        void Commit();

        IList<T> ObterTodos();
        T ObterPorId(int id);
        ValidationResult Gravar(T item);
        ValidationResult Excluir(int id);

    }
}