using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Builders;
using Workflow.BuildingBlocks.Configurations;

namespace Workflow.Bus.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBus>().UsingFactoryMethod(BusBuilder.CreateBus).LifestyleSingleton());
            container.Register(Component.For<IAdvancedBus>().UsingFactoryMethod(x => BusFactory.CreateAdvancedBus(new QueueDefinition ())).LifestyleSingleton());
        }
    }
}