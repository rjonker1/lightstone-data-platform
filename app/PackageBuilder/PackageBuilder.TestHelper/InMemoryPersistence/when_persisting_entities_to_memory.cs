﻿using NHibernate.Cfg;
using PackageBuilder.TestHelper.DbPersistence;

namespace PackageBuilder.TestHelper.InMemoryPersistence
{
    public class when_persisting_entities_to_memory : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            var configuration = Container.Resolve<Configuration>();
            configuration.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            configuration.SetProperty("connection.driver_class", "NHibernate.Driver.SQLite20Driver");
            configuration.SetProperty("dialect", "NHibernate.Dialect.SQLiteDialect");
            configuration.SetProperty("connection.connection_string", "Data Source=:memory:;Version=3;New=True;");
            configuration.SetProperty("connection.release_mode", "on_close");

            base.Observe();
        }
    }
}
