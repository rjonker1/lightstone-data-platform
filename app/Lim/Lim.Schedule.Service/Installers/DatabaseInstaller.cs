using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Domain.Entities.Factory;
using NHibernate;

namespace Lim.Schedule.Service.Installers
{
    public class DatabaseInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<DatabaseInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Database");

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(c => SessionFactory.Build("lim/schedule/database")).LifestyleSingleton());
            container.Register(Component.For<ISession>().UsingFactoryMethod(kernal => kernal.Resolve<ISessionFactory>().OpenSession()).LifestyleTransient());

            _log.InfoFormat("Database Installed Database");

            
        }
    }
}
