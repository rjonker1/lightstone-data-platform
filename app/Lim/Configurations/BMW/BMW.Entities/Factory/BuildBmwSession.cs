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
                    MsSqlConfiguration.MsSql2012.ConnectionString(Configurations.Bmw.ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.FinanceMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true))
                .BuildSessionFactory();
        }

        public static NHibernate.Cfg.Configuration BuildConfiguration(string connectionString)
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        System.Configuration.ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.FinanceMap>()).ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true))
                .BuildConfiguration();
        }
    }
}