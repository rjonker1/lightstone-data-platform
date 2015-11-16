using System;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.Extensions;
using UserManagement.TestHelper.Helpers;

namespace UserManagement.TestHelper.BaseTests
{
    public abstract class TestDataBaseHelper : BaseTestHelper
    {
        protected ISession Session;

        protected TestDataBaseHelper(bool useSingleSession = false)
        {
            Session = Container.Resolve<ISessionFactory>().OpenSession();

            if (useSingleSession)
                Container.Kernel.ComponentModelCreated += OverrideHelper.OverrideNhibernateSessionLifestyle;
        }

        //public TestDataBaseHelper(bool useSingleSession = false)
        //{
        //    HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize(); 

        //    Container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
        //    if (useSingleSession)
        //        Container.Kernel.ComponentModelCreated += OverrideHelper.OverrideNhibernateSessionLifestyle;

        //    Container.Install(new NHibernateInstaller());
        //    OverrideHelper.OverrideNhibernateCfg(Container);
        //}

        public void RefreshDb(bool useInMemoryDataBase = true)
        {
            var configuration = Container.Resolve<Configuration>();
            if (useInMemoryDataBase)
                OverrideDataBaseConnection(configuration);
            SchemaMetadataUpdater.QuoteTableAndColumns(configuration);
            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, new StreamWriter(new MemoryStream()));
        }

        private static void OverrideDataBaseConnection(Configuration configuration)
        {
            configuration.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            configuration.SetProperty("connection.driver_class", "NHibernate.Driver.SQLite20Driver");
            configuration.SetProperty("dialect", "NHibernate.Dialect.SQLiteDialect");
            configuration.SetProperty("connection.connection_string", "Data Source=nhibernate.db;Version=3");
            configuration.SetProperty("connection.release_mode", "on_close");
        }

        protected void SaveAndFlush(ISession session, params object[] objects)
        {
            foreach (var o in objects)
                session.SaveOrUpdate(o);
            session.Flush();
            foreach (var o in objects)
                session.Evict(o);
        }

        protected virtual void SaveAndFlush(params object[] objects)
        {
            Transaction(
                session =>
                {
                    SaveAndFlush(session, objects);
                });
        }

        protected T GetFromDb<T>(ISession session, T entity)
            where T : Entity
        {
            session.Evict(entity);
            var ret = session.Get<T>(entity.Id);
            return ret;
        }

        protected T GetFromDb<T>(T entity)
            where T : Entity
        {
            T fromDb = null;
            Transaction(
                sess =>
                {
                    fromDb = GetFromDb(sess, entity);
                });
            return fromDb;
        }

        protected void Transaction(Action<ISession> action)
        {
            try
            {
                Session.EncloseInTransaction(action);
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException && (ex as ObjectDisposedException).ObjectName == "AdoTransaction")
                    throw new Exception("System doesn't support nested transactions. Ensure that a transaction is not currently running.", ex);
                throw;
            }
        }
    }
}