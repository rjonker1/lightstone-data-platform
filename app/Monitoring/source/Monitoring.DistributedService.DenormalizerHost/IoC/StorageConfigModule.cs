using System.Configuration;
using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Monitoring.DistributedService.DenormalizerHost.Storage;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using Monitoring.Read.Denormalizer.DataProvider;
using Monitoring.Read.Persistence.Mappings.DataProviderMaps;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace Monitoring.DistributedService.DenormalizerHost.IoC
{
    public class StorageConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var factory = BuildNhibernateConfiguration();

            builder.RegisterInstance(factory);

            builder.Register(c => factory.OpenSession())
                .As<ISession>()
                .InstancePerDependency()
                .OnActivated(c => c.Instance.BeginTransaction());

            builder.RegisterType<NHibernateStorage>().As<IUpdateStorage>().InstancePerDependency();
            builder.RegisterType<DataProviderMonitoringHandler>();
            builder.RegisterType<QueueInitialization>().As<IInitializeQueues>();
        }

        private static ISessionFactory BuildNhibernateConfiguration()
        {

            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        ConfigurationManager.ConnectionStrings["Monitoring.ReadModel"].ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataProviderMonitoringPerformanceMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataProviderMonitoringFaultMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataProviderMonitoringSecurityMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataProviderMonitoringConfigurationMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataProviderMonitoringTransformationMap>())
                .ExposeConfiguration(BuildMonitoringReadSchema).BuildSessionFactory();
        }

        private static void BuildMonitoringReadSchema(Configuration config)
        {
            var schema = new SchemaExport(config);
            schema.Drop(false, true);
            schema.Create(false, true);
        }
    }
}
