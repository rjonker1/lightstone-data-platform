﻿using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Packages.Read;
using PackageBuilder.Infrastructure.NHibernate.Conventions;
using PackageBuilder.Infrastructure.NHibernate.MappingOverrides;

namespace PackageBuilder.Api.Installers
{
    /// <summary>
    /// Responsible for configuring NHibernate
    /// </summary>
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var configure = new Configuration().Configure();
            container.Register(Component.For<Configuration>().UsingFactoryMethod(() => Fluently.Configure(configure)
                .Mappings(cfg =>
                {
                    cfg.AutoMappings
                        .Add(AutoMap.AssemblyOf<Package>()
                            .Where(type => type.IsSubclassOf(typeof (Entity)))
                            .IgnoreBase<Entity>()
                            .Conventions.Add
                            (
                                ConventionBuilder.Id.Always(x => x.GeneratedBy.Assigned()),
                                ForeignKey.EndsWith("Id"),
                                new DomainSignatureConvention()
                            )
                            .UseOverridesFromAssemblyOf<PackageMappingOverride>());
                    //.Conventions.Add<>());
                    //cfg.FluentMappings.AddFromAssemblyOf<Entity>();
                })
                .ExposeConfiguration(TreatConfiguration).BuildConfiguration()));

            container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod(kernal => container.Resolve<Configuration>().BuildSessionFactory())
                .LifestyleSingleton());
            if (HttpContext.Current != null)
                container.Register(Component.For<ISession>()
                    .UsingFactoryMethod(kernal => kernal.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest());
            else // Sets lifestyle for testing to avoid -> Castle.MicroKernel.ComponentResolutionException, Looks like you forgot to register the http module Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule
                container.Register(Component.For<ISession>()
                    .UsingFactoryMethod(kernal => kernal.Resolve<ISessionFactory>().OpenSession())
                    .LifestyleTransient());
        }

        protected virtual void TreatConfiguration(Configuration configuration)
        {
            var update = new SchemaUpdate(configuration);
            update.Execute(false, true);
        }
    }
}
