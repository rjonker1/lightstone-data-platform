﻿using System;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using PackageBuilder.Core.Entities;
using PackageBuilder.TestHelper.Extensions;

namespace PackageBuilder.TestHelper.BaseTests
{
    public abstract class PhysicalTestDataBaseHelper : BaseTestHelper
    {
        protected ISession Session;

        protected PhysicalTestDataBaseHelper(bool useSingleSession = false)
        {
            if (useSingleSession)
                Container.Kernel.ComponentModelCreated += OverrideHelper.OverrideNhibernateSessionLifestyle;
        }

        public void RefreshDb()
        {
            Session = Container.Resolve<ISessionFactory>().OpenSession();
            // select * from dbo.sysobjects where id = object_id(N'PackageBuilderCommandStore.dbo.[Command]') and OBJECTPROPERTY(id, N'IsUserTable') = 1
            // the above query to check for existing objects will run per table in the database (schema), therefore we need to switch schemas to drop 
            // the tables before they are to be checked for and created by the latter packageBuilder schema, as the packageBuilderCommandStore schema is specified in the 
            // Nhibernate AutomappingOverride mapping to query both schemas via the packageBuilder SessionFactory will then be able to query accross the 2 schemas 
            // but will obviously only detect sysobjects per relevant schema. 
            var configuration = Container.Resolve<Configuration>();
            configuration.SetProperty("connection.connection_string_name", "packageBuilderCommandStore");
            new SchemaExport(configuration).Drop(true, true);
            configuration.SetProperty("connection.connection_string_name", "packageBuilder");
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
