using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Messaging.Publishing;
using MemBus;
using MemBus.Configurators;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Infrastructure.NEventStore;
using Workflow.BuildingBlocks;

namespace PackageBuilder.Api.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<MemBus.IBus>().Instance(BusSetup.StartWith<Conservative>()
                                                                     .Apply<IoCSupport>(s => s.SetAdapter(new MessageAdapter(container))
                                                                     .SetHandlerInterface(typeof(IHandleMessages<>)))
                                                                     .Construct()));

            container.Register(Component.For<IPublishStorableCommands>().ImplementedBy<PublishStorableCommands>());

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus("workflow/billing/queue"))//.CreateBus("workflow/billing/queue", container))
                    .LifestyleSingleton());

            container.Register(Component.For<IPublishIntegrationMessages>().ImplementedBy<IntegrationMessagePublisher>());
        }
    }
}