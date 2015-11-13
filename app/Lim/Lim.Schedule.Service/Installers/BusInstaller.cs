using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Lim.Domain.Messaging.Publishing;
using Lim.Schedule.Service.Reader;
using Workflow.BuildingBlocks;

namespace Lim.Schedule.Service.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<BusInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing bus");

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus(ConfigurationReader.LimSender))
                    .LifestyleSingleton()
                );
            
            container.Register(Component.For<IPublishConfigurationMessages>().UsingFactoryMethod(
                () =>
                    new ConfigurationMessagePublisher(
                        BusFactory.CreateAdvancedBus(ConfigurationReader.LimReceiver))));

            _log.InfoFormat("Bus Installed");
        }
    }
}