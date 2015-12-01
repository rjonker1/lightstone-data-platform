using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Publisher;

namespace Api.Helpers.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EasyNetQ.IBus>().UsingFactoryMethod(BusBuilder.CreateBus).LifestyleSingleton());
        }
    }
}