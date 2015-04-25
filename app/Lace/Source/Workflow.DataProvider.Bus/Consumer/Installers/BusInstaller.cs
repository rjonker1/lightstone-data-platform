using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Workflow.BuildingBlocks;

namespace Workflow.DataProvider.Bus.Consumer.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<BusInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing queue bus");

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus("workflow/dataprovider/queue"))
                    .LifestyleSingleton()
                );
        }
    }
}
