using System;
using System.IO;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.Entities;
using PackageBuilder.TestHelper.Extensions;
using Xunit.Extensions;

namespace PackageBuilder.TestHelper.DbPersistence
{
    public class when_persisting_entities_to_db : Specification
    {
        public IWindsorContainer Container = new WindsorContainer();
        protected ISession Session;

        public when_persisting_entities_to_db()
        {
            Container.Install(new NHibernateInstaller());
        }

        public override void Observe()
        {
            var configuration = Container.Resolve<Configuration>();
            configuration.SetProperty("cache.provider_class", "NHibernate.Cache.NoCacheProvider, NHibernate.Cache");
            configuration.SetProperty("cache.use_second_level_cache", "false");
            configuration.SetProperty("cache.use_query_cache", "false");
            configuration.SetProperty("current_session_context_class", "thread_static");
            configuration.SetProperty("show_sql", "true");

            Session = Container.Resolve<ISessionFactory>().OpenSession();

            new SchemaExport(Container.Resolve<Configuration>()).Execute(true, true, false, Session.Connection, new StreamWriter(new MemoryStream()));
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
