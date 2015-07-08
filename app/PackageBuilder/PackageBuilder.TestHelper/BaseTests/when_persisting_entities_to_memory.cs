using NHibernate.Cfg;

namespace PackageBuilder.TestHelper.BaseTests
{
    public class when_persisting_entities_to_memory : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            var configuration = Container.Resolve<Configuration>();
            configuration.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            configuration.SetProperty("connection.driver_class", "NHibernate.Driver.SQLite20Driver");
            configuration.SetProperty("dialect", "NHibernate.Dialect.SQLiteDialect");
            configuration.SetProperty("connection.connection_string", "Data Source=nhibernate.db;Version=3");
            configuration.SetProperty("connection.release_mode", "on_close");

            base.Observe();
        }
    }
}
