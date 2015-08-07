using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using Recoveries.Router.Configuration;
using Workflow.BuildingBlocks;

namespace Recoveries.Router.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAdvancedBus>()
                .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus(RecoveryReceiverQueueConfiguration.Receiver())).LifestyleSingleton());
        }
    }
}