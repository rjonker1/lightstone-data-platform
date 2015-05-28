using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Domain.Entities.Factory;
using NHibernate;
using NHibernate.Cfg;

namespace Lim.Schedule.Service.Installers
{
    public class DatabaseInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<DatabaseInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Database");

            container.Register(Component.For<Configuration>().UsingFactoryMethod(c => SessionFactory.BuildConfiguration("lim/schedule/database")).LifestyleTransient());
            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(c => c.Resolve<Configuration>().BuildSessionFactory()).LifestyleSingleton());
            container.Register(Component.For<ISession>().UsingFactoryMethod(c => c.Resolve<ISessionFactory>().OpenSession()).LifestyleTransient());

            _log.InfoFormat("Installed Database");
        }
    }
}
