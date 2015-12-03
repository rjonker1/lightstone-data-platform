using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lim.Infrastructure;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Lim.Domain.EventStore.Factory
{
    public sealed class LimEventStoreManager
    {
        private static readonly ISessionFactory _limEventStore = BuildSession();

        static LimEventStoreManager()
        {
        }

        public static ISessionFactory LimEventStoreInstance
        {
            get { return _limEventStore; }
        }

        private static ISessionFactory BuildSession()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.LimEventStore.ConnectionString))
               // .Mappings(m => m.FluentMappings.Add<Maps.DataSetMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.LimEventStore.UpdateDatabase))
                .BuildSessionFactory();
        }

        public static LimEventStoreConfiguration BuildConfiguration()
        {
            return (LimEventStoreConfiguration)Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.LimEventStore.ConnectionString))
               // .Mappings(m => m.FluentMappings.Add<Maps.DataSetMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.LimEventStore.UpdateDatabase))
                .BuildConfiguration();
        }
    }

    public class LimEventStoreConfiguration : NHibernate.Cfg.Configuration
    {

    }
}

