using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MemBus;
using MemBus.Configurators;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Infrastructure.NEventStore;

namespace PackageBuilder.Api.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBus>().Instance(BusSetup.StartWith<Conservative>()
                                                                      .Apply<IoCSupport>(s => s.SetAdapter(new MessageAdapter(container))
                                                                      .SetHandlerInterface(typeof(IHandleMessages<>)))
                                                                      .Construct()));
            container.Register(Component.For<IPublishStorableCommands>().ImplementedBy<PublishStorableCommands>());
        }
    }
}