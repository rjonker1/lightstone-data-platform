using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.NHibernate.Conventions;

namespace UserManagement.Api.Installers
{
    class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            var configure = new Configuration().Configure();
            container.Register(Component.For<Configuration>().UsingFactoryMethod(() => Fluently.Configure(configure)
                .Mappings(cfg => cfg.AutoMappings

                    .Add(AutoMap.AssemblyOf<User>()
                        .Where(type => type.IsSubclassOf(typeof(Entity)))
                        .IgnoreBase<Entity>()
                        .Conventions.Add
                        (
                            ConventionBuilder.Id.Always(x => x.GeneratedBy.Assigned()),
                            ForeignKey.EndsWith("Id"),
                            new DomainSignatureConvention()
                        )
                        )).BuildConfiguration()));

            container.Register(Component.For<ISessionFactory>()
                     .UsingFactoryMethod(kernal => container.Resolve<Configuration>().BuildSessionFactory())
                     .LifestyleSingleton());
            container.Register(Component.For<ISession>()
                     .UsingFactoryMethod(kernal =>
                         kernal.Resolve<ISessionFactory>().OpenSession()
                         )
                     .LifestylePerWebRequest());
        }

    }
}

