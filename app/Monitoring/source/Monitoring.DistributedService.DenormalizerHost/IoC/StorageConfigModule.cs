using System.Configuration;
using Autofac;
using Monitoring.DistributedService.DenormalizerHost.Storage;
using Monitoring.Domain.Core.Contracts;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Configuration = NHibernate.Cfg.Configuration;

namespace Monitoring.DistributedService.DenormalizerHost.IoC
{
    public class StorageConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = BuildNihbernateConfiguration();
            var factory = configuration.BuildSessionFactory();

            builder.RegisterInstance(factory);

            builder.Register(c => factory.OpenSession())
                .As<ISession>()
                .InstancePerDependency()
                .OnActivated(c => c.Instance.BeginTransaction());

            builder.RegisterType<NHibernateStorage>().As<IUpdateStorage>().InstancePerDependency();
        }

        private static Configuration BuildNihbernateConfiguration()
        {
            var configuration = new Configuration();
            configuration.SessionFactoryName("Monitoring.Read.ReadModel");

            configuration.DataBaseIntegration(d =>
            {
                d.Dialect<MsSql2008Dialect>();
                d.Driver<SqlClientDriver>();
                d.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                d.ConnectionString = ConfigurationManager.ConnectionStrings["Monitoring.ReadModel"].ConnectionString;
                d.LogSqlInConsole = false;
                d.LogFormattedSql = true;
            });

            //TODO: Add mappings assembly
            //configuration.AddAssembly(typeof ());

            return configuration;
        }
    }
}
