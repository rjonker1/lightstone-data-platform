using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Reader;
using Workflow.Lace.Messages.Shared;

namespace Workflow.DataProvider.Bus.Consumer.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<BusInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing bus and queue publishers");

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus(ConfigurationReader.Workflow))
                    .LifestyleSingleton()
                );

            container.Register(
                Component.For<IPublishCommandMessages>()
                    .UsingFactoryMethod(
                        () =>
                            new WorkflowCommandPublisher(
                                BusFactory.CreateAdvancedBus(ConfigurationReader.Workflow))));

            container.Register(
                Component.For<IPublishBillingMessages>()
                    .UsingFactoryMethod(
                        () =>
                            new BillingPublisher(
                                BusFactory.CreateAdvancedBus(ConfigurationReader.Billing))));

            container.Register(
                Component.For<IPublishEventMessages>()
                    .UsingFactoryMethod(
                        () =>
                            new EventPublisher(
                                BusFactory.CreateAdvancedBus(ConfigurationReader.Receiver))));
        }
    }

    
}