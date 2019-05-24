using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Red.Domain.Interfaces.Repository;
using Red.Repository.Context;
using Red.Repository.Interface;

namespace Red.Repository.Base
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected readonly RedContext Context;
        protected IDbSet<TEntidade> DbSet;

        public RepositorioBase(IContextManager contextManager)
        {
            Context = contextManager.GetContext();

            this.Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            this.DbSet = this.Context.Set<TEntidade>();
        }

        public IDbConnection Connection => new SqlConnection(ConfigurationManager.ConnectionStrings["CredPayContext"].ConnectionString);

        public virtual void Adicionar(TEntidade obj)
        {
            var entry = this.Context.Entry(obj);
            this.DbSet.Add(obj);
            entry.State = EntityState.Added;
        }

        public virtual void Atualizar(TEntidade obj)
        {
            var entry = this.Context.Entry(obj);
            this.DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
            //this.Context.Dispose();
            //GC.SuppressFinalize(this);
        }

        public virtual TEntidade ObterPorId(int id)
        {
            try
            {
                var resultado = this.DbSet.Find(id);

                //if (resultado != null)
                //    this.Context.Entry(resultado).State = EntityState.Detached;

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return this.DbSet.ToList();
        }

        public virtual IEnumerable<TEntidade> ObterTodosPaginado(int pagina, int registros)
        {
            var resultado = this.DbSet.Take(pagina).Skip(registros);

            return this.DbSet.ToList();
        }

        public virtual IEnumerable<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }

        public virtual void Remover(TEntidade obj)
        {
            var entry = this.Context.Entry(obj);
            this.DbSet.Remove(obj);
            entry.State = EntityState.Deleted;
        }
    }
}