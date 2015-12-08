using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.BuildingBlocks.DependencyInjection;

namespace Shared.Logging.Installers
{
    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDataPlatformLogger>().ImplementedBy<DataPlatformLogger>().LifestyleSingleton());
        }
    }
}