using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Packages.ReadModels;

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
                                PrimaryKey.Name.Is(o => "Id"),
                                ForeignKey.EndsWith("Id")
                            ));
                    //.UseOverridesFromAssemblyOf<>()
                    //.Conventions.Add<>());
                    //cfg.FluentMappings.AddFromAssemblyOf<Entity>();
                }).BuildConfiguration()));

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
