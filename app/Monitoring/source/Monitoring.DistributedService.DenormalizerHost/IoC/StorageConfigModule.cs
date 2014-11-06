using System;
using System.Configuration;
using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Monitoring.DistributedService.DenormalizerHost.Storage;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Read.Denormalizer.DataProvider;
using Monitoring.Read.Persistence.Mappings.DataProviderMaps;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace Monitoring.DistributedService.DenormalizerHost.IoC
{
    public class StorageConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var configuration = BuildNhibernateConfiguration();
            //var factory = configuration.BuildSessionFactory();
            var factory = BuildNhibernateConfiguration();

            builder.RegisterInstance(factory);

            builder.Register(c => factory.OpenSession())
                .As<ISession>()
                .InstancePerDependency()
                .OnActivated(c => c.Instance.BeginTransaction());

            builder.RegisterType<NHibernateStorage>().As<IUpdateStorage>().InstancePerDependency();
            builder.RegisterType<DataProviderEventsUpdater>();
        }

        private static ISessionFactory BuildNhibernateConfiguration()
        {

            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        ConfigurationManager.ConnectionStrings["Monitoring.ReadModel"].ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataProviderEventMap>())
                .ExposeConfiguration(BuildMonitoringReadSchema).BuildSessionFactory();

            //var configuration = new Configuration();
            //configuration.SessionFactoryName("Monitoring.Read.ReadModel");

            //configuration.DataBaseIntegration(d =>
            //{
            //    d.Dialect<MsSql2008Dialect>();
            //    d.Driver<SqlClientDriver>();
            //    d.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            //    d.ConnectionString = ConfigurationManager.ConnectionStrings["Monitoring.ReadModel"].ConnectionString;
            //    d.LogSqlInConsole = false;
            //    d.LogFormattedSql = true;
            //});

            ////TODO: Add mappings assembly
            ////configuration.AddAssembly(typeof ());
            //configuration.AddAssembly(typeof(DataProviderEventMap).Assembly);


            //return configuration;
        }

        private static void BuildMonitoringReadSchema(Configuration config)
        {
            var schema = new SchemaExport(config);
            schema.Drop(false, true);
            schema.Create(false, true);
        }
    }
}
