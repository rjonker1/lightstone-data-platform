using Billing.Infrastructure.NHibernate.Conventions;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Workflow.Billing.Helpers.AutoMapper.MappingOverrides;
using Workflow.Billing.Infrastructure.NHibernate;

namespace Workflow.Billing.Consumer.Installers
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install NHibernateInstaller for WorkFlow");

            container.Register(Component.For<Configuration>().UsingFactoryMethod(() =>
            {
                var buildConfiguration = Fluently.Configure(new Configuration().Configure())
                    .Mappings(
                        cfg => cfg.AutoMappings.Add(new AutoPersistenceModelConfiguration().GetAutoPersistenceModel()))
                    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<BillingMappingOverride>())
                    .ExposeConfiguration(ExportSchemaConfig)
                    .BuildConfiguration();
                return buildConfiguration;
            }).LifestyleTransient());

            container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod(kernal => kernal.Resolve<Configuration>().BuildSessionFactory())
                .LifestyleSingleton());
            container.Register(Component.For<ISession>()
                .UsingFactoryMethod(kernal => kernal.Resolve<ISessionFactory>().OpenSession())
                .LifestyleTransient());

            //Initialize ISession to build up first run schema
            //var init = container.Resolve<ISession>();

            this.Info(() => "Successfully installed NHibernateInstaller for WorkFlow");
        }

        protected virtual void ExportSchemaConfig(Configuration config)
        {
            //config.SetInterceptor(new TrackingInterceptor());
            //config.SetInterceptor(new NhInterceptor());
            SchemaMetadataUpdater.QuoteTableAndColumns(config);

            var update = new SchemaUpdate(config);
            update.Execute(false, true);

            //new SchemaExport(config).Drop(false, true);
            //new SchemaExport(config).Create(false, true);
        }
    }
}