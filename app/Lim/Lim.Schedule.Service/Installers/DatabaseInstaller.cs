using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Domain.Entities.Factory;
using NHibernate.Cfg;
using Toolbox.Bmw.Entities.Factory;

namespace Lim.Schedule.Service.Installers
{
    public class DatabaseInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<DatabaseInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Database");
            container.Register(Component.For<Configuration>().UsingFactoryMethod(c => FactoryManager.BuildConfiguration()).LifestyleTransient());
            _log.InfoFormat("Installed Database");
        }
    }
}