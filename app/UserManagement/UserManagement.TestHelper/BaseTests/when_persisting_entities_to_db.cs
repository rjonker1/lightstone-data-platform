using System;
using System.IO;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using UserManagement.Api.Installers;
using UserManagement.Domain.Core.Entities;
using UserManagement.TestHelper.Extensions;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.TestHelper.BaseTests
{
    public class when_persisting_entities_to_db : Specification
    {
        public IWindsorContainer Container = new WindsorContainer();
        protected ISession Session;

        public when_persisting_entities_to_db(bool useSingleSession = false)
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize(); 

            Container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            if (useSingleSession)
                Container.Kernel.ComponentModelCreated += OverrideHelper.OverrideNhibernateSessionLifestyle;

            Container.Install(new NHibernateInstaller());
            OverrideHelper.OverrideNhibernateCfg(Container);
        }

        public override void Observe()
        {
            Session = Container.Resolve<ISessionFactory>().OpenSession();
            var configuration = Container.Resolve<Configuration>();
            SchemaMetadataUpdater.QuoteTableAndColumns(configuration);
            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, new StreamWriter(new MemoryStream()));
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