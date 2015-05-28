using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Lim.Domain.Entities.Factory
{
    public class SessionFactory
    {
        public static ISessionFactory BuildSession(string connectionString)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.ActionTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.AuthenticationTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.FrequencyTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ClientMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ConfigurationMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ConfigurationApiMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationClientsMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationContractsMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationPackagesMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.PackageResponsesMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.AuditApiIntegrationMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false,true))
                .BuildSessionFactory();
        }

        public static NHibernate.Cfg.Configuration BuildConfiguration(string connectionString)
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        System.Configuration.ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
                .Mappings(m => m.FluentMappings.Add<Maps.ActionTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.AuthenticationTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.FrequencyTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationTypeMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ClientMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ConfigurationMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ConfigurationApiMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationClientsMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationContractsMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationPackagesMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.PackageResponsesMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.AuditApiIntegrationMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true))
                .BuildConfiguration();
        }
    }
}
