using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using Workflow.Publisher;

namespace Workflow.Bus.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBus>().UsingFactoryMethod(BusBuilder.CreateBus).LifestyleSingleton());
        }
    }
}