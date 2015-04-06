using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using Workflow.BuildingBlocks;

namespace Workflow.Billing.Producer.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IBus>()
                    .UsingFactoryMethod(() => new BusFactory().CreateBus("workflow/billing/queue", container))
                    .LifestyleSingleton()
                );
        }
    }
}