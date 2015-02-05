﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using UserManagement.Infrastructure.NHibernate;

namespace UserManagement.Api.Installers
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Configuration>().UsingFactoryMethod(() =>
                Fluently.Configure(new Configuration().Configure())
                    .Mappings(cfg => cfg.AutoMappings.Add(new AutoPersistenceModelConfiguration().GetAutoPersistenceModel()))
                    .ExposeConfiguration(ExportSchemaConfig)
                    .BuildConfiguration()).LifestyleTransient());
            
            container.Register(Component.For<ISessionFactory>()
                     .UsingFactoryMethod(kernal => kernal.Resolve<Configuration>().BuildSessionFactory())
                     .LifestyleSingleton());
            container.Register(Component.For<ISession>()
                     .UsingFactoryMethod(kernal => kernal.Resolve<ISessionFactory>().OpenSession())
                     .LifestylePerWebRequest());
        }

        protected virtual void ExportSchemaConfig(Configuration config)
        {
            SchemaMetadataUpdater.QuoteTableAndColumns(config);
            var update = new SchemaUpdate(config);
            update.Execute(false, true);

            //new SchemaExport(config).Drop(false, true);
            //new SchemaExport(config).Create(false, true);
        }
    }
}

