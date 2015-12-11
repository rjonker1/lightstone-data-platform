using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lim.Infrastructure;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Toolbox.LSAuto.Entities.Factory
{
    public sealed class LightstoneAutoFactoryManager
    {
        private static readonly ISessionFactory _lsAutoInstance = BuildSession();

        static LightstoneAutoFactoryManager()
        {
        }

        public static ISessionFactory Instance
        {
            get { return _lsAutoInstance; }
        }

        private static ISessionFactory BuildSession()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.LsAuto.ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseExtractMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseExtractFieldMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseViewMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseViewColumnMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.LsAuto.UpdateDatabase))
                .BuildSessionFactory();
        }

        public static LsAutoConfiguration BuildConfiguration()
        {
            return (LsAutoConfiguration) Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.LsAuto.ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseExtractMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseExtractFieldMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseViewMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.DatabaseViewColumnMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.LsAuto.UpdateDatabase))
                .BuildConfiguration();
        }
    }

    public class LsAutoConfiguration : NHibernate.Cfg.Configuration
    {

    }
}