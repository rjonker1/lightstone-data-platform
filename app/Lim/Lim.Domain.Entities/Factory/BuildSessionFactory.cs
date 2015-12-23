using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lim.Infrastructure;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Lim.Domain.Entities.Factory
{
    public sealed class FactoryManager
    {
        private static readonly ISessionFactory _instance = BuildSession();

        static FactoryManager()
        {
        }

        public static ISessionFactory Instance
        {
            get { return _instance; }
        }

        private static ISessionFactory BuildSession()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.Lim.ConnectionString))
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
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationTrackingMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.PackageMetadataMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationDataExtractMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ConfigurationFtpMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.Lim.UpdateDatabase))
                .BuildSessionFactory();
        }

        public static NHibernate.Cfg.Configuration BuildConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationReader.Lim.ConnectionString))
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
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationTrackingMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.PackageMetadataMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.IntegrationDataExtractMap>())
                .Mappings(m => m.FluentMappings.Add<Maps.ConfigurationFtpMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, ConfigurationReader.Lim.UpdateDatabase))
                .BuildConfiguration();
        }
    }
}