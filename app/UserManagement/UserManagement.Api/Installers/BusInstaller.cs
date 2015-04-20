using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using EasyNetQ;
using MemBus;
using MemBus.Configurators;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Infrastructure;
using Workflow.BuildingBlocks;
using IBus = MemBus.IBus;

namespace UserManagement.Api.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install BusInstaller");

            container.Register(Component.For<IBus>().Instance(BusSetup.StartWith<Conservative>()
                                                                     .Apply<IoCSupport>(s => s.SetAdapter(new MessageAdapter(container))
                                                                     .SetHandlerInterface(typeof(IHandleMessages<>)))
                                                                     .Construct()));

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus("workflow/billing/queue"))//.CreateBus("workflow/billing/queue", container))
                    .LifestyleSingleton()
                );

            this.Info(() => "Successfully installed BusInstaller");
        }
    }
}