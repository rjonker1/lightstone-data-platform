using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Lim.Core;
using Lim.Domain.Messaging;
using Lim.Domain.Messaging.Publishing;
using Lim.Schedule.Service.Reader;
using Workflow.BuildingBlocks;

namespace Lim.Schedule.Service.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        private static readonly ILog _log = LogManager.GetLogger<BusInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing bus");

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus(ConfigurationReader.LimSender)).LifestyleSingleton()
                );

            container.Register(Component.For<IPublishConfigurationMessages>().UsingFactoryMethod(
                () =>
                    new ConfigurationMessagePublisher(
                        BusFactory.CreateAdvancedBus(ConfigurationReader.LimReceiver))));

            container.Register(Component.For<IPublish>().UsingFactoryMethod(
                () => new PublishMessage(BusFactory.CreateAdvancedBus(ConfigurationReader.LimReceiver))));

            container.Register(Component.For<ISendCommand>().UsingFactoryMethod(
                () => new SendCommand(BusFactory.CreateAdvancedBus(ConfigurationReader.LimSender))));

            _log.InfoFormat("Bus Installed");
        }
    }
}