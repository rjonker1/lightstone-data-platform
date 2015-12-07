using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Workflow.BuildingBlocks.Builders;

namespace Workflow.Billing.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<BusInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing bus");

            //container.Register(
            //    Component.For<IBus>()
            //        .UsingFactoryMethod(() => new BusFactory().CreateBus("workflow/billing/queue", container))
            //        .LifestyleSingleton()
            //    );

            container.Register(Component.For<EasyNetQ.IBus>().UsingFactoryMethod(BusBuilder.CreateBus).LifestyleSingleton());

            container.Register(
                Component.For<IAdvancedBus>()
                    .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus("workflow/billing/queue"))
                    .LifestyleSingleton()
                );
        }
    }
}