using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Data;
using NHibernate.Cfg;

namespace PackageBuilder.Api.Installers
{
    /// <summary>
    /// Responsible for configuring NHibernate
    /// </summary>
    public class NHibernateInstaller : IWindsorInstaller
    {
        //public static Configuration Build()
        //{
        //    var configuration = new Configuration().Configure();

        //    return Fluently.Configure(configuration)
        //        .Mappings(cfg =>
        //        {
        //            //cfg.FluentMappings.AddFromAssemblyOf<>();
        //        }).BuildConfiguration();
        //}

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var configuration = new Configuration().Configure();
            container.Register(Component.For<Configuration>().UsingFactoryMethod(() => Fluently.Configure(configuration)
                .Mappings(cfg =>
                {
                    cfg.AutoMappings.Add(AutoMap.AssemblyOf<Entity>());
                    //cfg.FluentMappings.AddFromAssemblyOf<>();
                }).BuildConfiguration()));
        }
    }
}
