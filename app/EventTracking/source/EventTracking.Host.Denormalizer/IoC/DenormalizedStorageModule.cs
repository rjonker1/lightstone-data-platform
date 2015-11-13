using System.Configuration;
using Autofac;
using EventTracking.Domain.Core.Contracts;
using EventTracking.Host.Denormalizer.Storage;
using EventTracking.Read.Normalizer.Handlers.ForDataProviders;
using EventTracking.Read.Persistence.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace EventTracking.Host.Denormalizer.IoC
{
    public class DenormalizedStorageModule : Module
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
            builder.RegisterType<DataProviderEventsHandler>();
        }

        private static ISessionFactory BuildNhibernateConfiguration()
        {

            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        ConfigurationManager.ConnectionStrings["EventTracking.ReadModel"].ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataProviderEventMap>())
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
