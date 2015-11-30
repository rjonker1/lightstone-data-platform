using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using MemBus;
using MemBus.Configurators;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Infrastructure;
using Workflow.BuildingBlocks;
using Workflow.Publisher;

namespace UserManagement.Api.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EasyNetQ.IBus>().UsingFactoryMethod(BusBuilder.CreateBus).LifestyleSingleton());

            container.Register(Component.For<MemBus.IBus>().Instance(BusSetup.StartWith<Conservative>()
                                                                     .Apply<IoCSupport>(s => s.SetAdapter(new MessageAdapter(container))
                                                                     .SetHandlerInterface(typeof(IHandleMessages<>)))
                                                                     .Construct()));

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus("workflow/billing/queue"))
                    .LifestyleSingleton()
                );
        }
    }
}