using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lim.Infrastructure;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Toolbox.Bmw.Entities.Factory
{
    public sealed class BmwFactoryManager
    {
        private static readonly ISessionFactory _bmwinstance = BuildSession();

        static BmwFactoryManager()
        {
        }

        public static ISessionFactory BmwInstance
        {
            get { return _bmwinstance; }
        }

        private static ISessionFactory BuildSession()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.Bmw.ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.FinanceMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.Bmw.UpdateDatabase))
                .BuildSessionFactory();
        }

        public static BmwConfiguration BuildConfiguration()
        {
            return (BmwConfiguration)Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.Bmw.ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.FinanceMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.Bmw.UpdateDatabase))
                .BuildConfiguration();
        }
    }

    public class BmwConfiguration : NHibernate.Cfg.Configuration
    {
        
    }
}