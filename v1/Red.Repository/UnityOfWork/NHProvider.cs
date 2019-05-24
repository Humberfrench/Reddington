using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Red.Repository.UnityOfWork
{
    /// <summary>
    /// Classe Provider, de acesso a dados via NHibernate.
    /// </summary>
    /// <typeparam name="TClassName">Nome da Classe Base a ser usada</typeparam>
    /// <typeparam name="TClassId">Tipo de ID da classe</typeparam>
    /// <remarks></remarks>
    public class NhProvider<TClassName, TClassId> : IDisposable
    {

        // To detect redundant calls
        private bool disposedValue = false;

        /// <summary>
        /// Construtor do Objeto
        /// </summary>
        /// <remarks></remarks>

        public NhProvider()
        {

        }

        /// <summary>
        /// Efetua a inclusão de um registro
        /// </summary>
        /// <param name="oPersist">Objeto do Model contendo os dados</param>
        /// <remarks></remarks>
        public virtual void Add(TClassName oPersist)
        {
            Configuration oConfig = new Configuration();
            ISessionFactory oFactory = null;
            ISession oSession = null;
            ITransaction oTransaction = null;


            try
            {
                //definindo o assembly para carregar os arquivo .hbm.xml  
                //que fazem parte do mesmo
                oConfig.AddAssembly(Assembly.GetCallingAssembly());

                //criando uma sessao e iniciando uma transação
                oFactory = oConfig.BuildSessionFactory();
                oSession = oFactory.OpenSession();
                oTransaction = oSession.BeginTransaction();

                //persistindo os dados no banco de dados
                oSession.Save(oPersist);

                //fecha a transação e a sessão
                oTransaction.Commit();
                oSession.Close();

                oConfig = null;
                oFactory = null;
                oSession = null;
                oTransaction = null;

            }
            catch (Exception ex)
            {
                oTransaction.Rollback();
                oSession.Close();
                oConfig = null;
                oFactory = null;
                oSession = null;
                oTransaction = null;
                throw ex;
            }

        }

        /// <summary>
        /// Efetua a atualização de um registro
        /// </summary>
        /// <param name="oPersist">Objeto do Model contendo os dados</param>
        /// <remarks></remarks>
        public virtual void Update(TClassName oPersist)
        {
            Configuration oConfig = new Configuration();
            ISessionFactory oFactory = null;
            ISession oSession = null;
            ITransaction oTransaction = null;


            try
            {
                //definindo o assembly para carregar os arquivo .hbm.xml  que fazem parte do mesmo
                oConfig.AddAssembly(Assembly.GetCallingAssembly());

                //criando uma sessao e iniciando uma transação
                oFactory = oConfig.BuildSessionFactory();
                oSession = oFactory.OpenSession();
                oTransaction = oSession.BeginTransaction();

                //persistindo os dados no banco de dados
                oSession.Update(oPersist);

                //fecha a transação e a sessão
                oTransaction.Commit();
                oSession.Close();

                oConfig = null;
                oFactory = null;
                oSession = null;
                oTransaction = null;

            }
            catch (Exception ex)
            {
                oTransaction.Rollback();
                oSession.Close();
                oConfig = null;
                oFactory = null;
                oSession = null;
                oTransaction = null;
                throw ex;
            }

        }

        /// <summary>
        /// Efetua a buasca de um registro
        /// </summary>
        /// <param name="oValue">Valor do ID para a busca</param>
        /// <returns>Booleando para a função</returns>
        /// <remarks></remarks>
        public virtual TClassName Get(TClassId oValue)
        {

            Configuration oConfig = new Configuration();
            ISessionFactory oFactory = null;
            ISession oSession = null;
            TClassName oModel;

            try
            {
                //definindo o assembly para carregar os arquivo .hbm.xml  que fazem parte do mesmo
                oConfig.AddAssembly(Assembly.GetCallingAssembly());

                //criando uma sessao e iniciando uma transação
                oFactory = oConfig.BuildSessionFactory();
                oSession = oFactory.OpenSession();

                //???
                oModel = (TClassName) oSession.Load(typeof(TClassId), oValue);

                oSession.Flush();

                //fecha a transação e a sessão
                oSession.Close();

                oConfig = null;
                oFactory = null;
                oSession = null;

            }
            catch (Exception ex)
            {
                oSession.Close();
                oConfig = null;
                oFactory = null;
                oSession = null;
                throw ex;
            }

            return oModel;

        }

        /// <summary>
        /// Efetua a lista de registros
        /// </summary>
        /// <returns>Booleando para a função</returns>
        /// <remarks></remarks>
        public virtual IList<TClassName> List()
        {

            Configuration oConfig = new Configuration();
            ISessionFactory oFactory = null;
            ISession oSession = null;
            IList iLstReturn = null;
            List<TClassName> lstReturn = null;

            try
            {
                //definindo o assembly para carregar os arquivo .hbm.xml  que fazem parte do mesmo
                oConfig.AddAssembly(Assembly.GetCallingAssembly());

                //criando uma sessao e iniciando uma transação
                oFactory = oConfig.BuildSessionFactory();
                oSession = oFactory.OpenSession();

                //list = session.CreateCriteria(GetType(T)).List(Of T)()
                iLstReturn = oSession.CreateCriteria(typeof(TClassName)).List();

                lstReturn = new List<TClassName>();

                foreach (TClassName oObject in iLstReturn)
                {
                    lstReturn.Add(oObject);
                }

                //fecha a transação e a sessão
                oSession.Close();

                oConfig = null;
                oFactory = null;
                oSession = null;

            }
            catch (Exception ex)
            {
                oSession.Close();
                oConfig = null;
                oFactory = null;
                oSession = null;
                throw ex;
            }

            return lstReturn;

        }

        /// <summary>
        /// Efetua a exclusão de um registro
        /// </summary>
        /// <param name="oPersist">Objeto do Model contendo os dados</param>
        /// <remarks></remarks>
        public virtual void Del(ref TClassName oPersist)
        {
            Configuration oConfig = new Configuration();
            ISessionFactory oFactory = null;
            ISession oSession = null;
            ITransaction oTransaction = null;

            try
            {
                //definindo o assembly para carregar os arquivo .hbm.xml  que fazem parte do mesmo
                oConfig.AddAssembly(Assembly.GetCallingAssembly());

                //criando uma sessao e iniciando uma transação
                oFactory = oConfig.BuildSessionFactory();
                oSession = oFactory.OpenSession();
                oTransaction = oSession.BeginTransaction();

                oSession.Delete(oPersist);

                oSession.Flush();

                //fecha a transação e a sessão
                oTransaction.Commit();
                oSession.Close();

                oConfig = null;
                oFactory = null;
                oSession = null;
                oTransaction = null;

            }
            catch (Exception ex)
            {
                oTransaction.Rollback();
                oSession.Close();
                oConfig = null;
                oFactory = null;
                oSession = null;
                oTransaction = null;
                throw ex;
            }

        }

        public virtual IList<TClassName> LoadByQuery(string hsqlQuery)
        {
            List<TClassName> lstReturn = new List<TClassName>();
            IList iLstReturn = null;
            Configuration oConfig = new Configuration();
            ISessionFactory oFactory = null;
            ISession oSession = null;

            try
            {
                //definindo o assembly para carregar os arquivo .hbm.xml  que fazem parte do mesmo
                oConfig.AddAssembly(Assembly.GetCallingAssembly());

                //criando uma sessao e iniciando uma transação
                oFactory = oConfig.BuildSessionFactory();
                oSession = oFactory.OpenSession();

                iLstReturn = oSession.CreateQuery(hsqlQuery).List();

                lstReturn = new List<TClassName>();

                foreach (TClassName oData in iLstReturn)
                {
                    lstReturn.Add(oData);
                }

                //fecha a transação e a sessão
                oSession.Close();

                oConfig = null;
                oFactory = null;
                oSession = null;
                iLstReturn = null;

            }
            catch (Exception ex)
            {
                oSession.Close();
                oConfig = null;
                oFactory = null;
                oSession = null;
                iLstReturn = null;
                throw ex;
            }

            return lstReturn;

        }

        #region " IDisposable Support "

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: free other state (managed objects).
                }

                // TODO: free your own state (unmanaged objects).
                // TODO: set large fields to null.
            }
            this.disposedValue = true;
        }
        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
