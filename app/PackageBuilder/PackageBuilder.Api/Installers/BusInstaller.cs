using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MemBus;
using MemBus.Configurators;
using PackageBuilder.Domain.MessageHandling;

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
        }
    }
}