using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Red.Domain.Interfaces;
using System;

namespace Red.Repository.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private static readonly ISessionFactory SessionFactory;
        private ITransaction _transaction;
        private const string CURRENT_SESSION_KEY = "nhibernate.current_session";
        private static readonly object Factorylock = new object();

        public ISession Session { get; private set; }

        static UnityOfWork()
        {
            lock (Factorylock)
            {
                Configuration cfg = new Configuration();
                cfg.Configure();
                
                SessionFactory = Fluently.Configure(cfg)
                                .CurrentSessionContext("web")
                                .Mappings(m =>
                                            m.FluentMappings
                                                .AddFromAssemblyOf<NHibernateHelper>()
                                                .Conventions.AddFromAssemblyOf<NHibernateHelper>()
                                                .Conventions.Add(DefaultAccess.CamelCaseField(CamelCasePrefix.None)))
                                .BuildSessionFactory();

            } 

        }
        public void Salvar(IEntidade entidade)
        {
            Session.Clear();
            BeginTransaction();
            Session.SaveOrUpdate(entidade);
            Commit();
        }

        public void Excluir(IEntidade entidade)
        {
            BeginTransaction();
            Session.Delete(entidade);
            Commit();
        }

        public UnityOfWork()
        {
            Session = SessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }

        public static void CreationDb()
        {
            FluentConfiguration config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Data Source=.\\Web;Initial Catalog=dbCECAM16;Integrated Security=False;User ID=sa;Password=123456"))
                .Mappings(m => m.FluentMappings.Add<Mappings.AlunoMap>())
                .Mappings(m => m.FluentMappings.Add<Mappings.AtividadesPreferidaMap>())
                .Mappings(m => m.FluentMappings.Add<Mappings.CaracteristicaMap>())
                .Mappings(m => m.FluentMappings.Add<Mappings.EvangelizadorMap>())
                .Mappings(m => m.FluentMappings.Add<Mappings.ProblemasSaudeMap>())
                .Mappings(m => m.FluentMappings.Add<Mappings.ResponsavelMap>())
                .Mappings(m => m.FluentMappings.Add<Mappings.StatusMap>())
                .Mappings(m => m.FluentMappings.Add<Mappings.TurmaMap>());

            config.ExposeConfiguration(
                      c => new SchemaExport(c).Execute(true, true, false))
                 .BuildConfiguration();
        }
    }
}

