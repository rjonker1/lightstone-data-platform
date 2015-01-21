using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MemBus;
using MemBus.Configurators;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Infrastructure;

namespace UserManagement.Api.Installers
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