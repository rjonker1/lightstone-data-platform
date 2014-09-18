using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.Helpers.Windsor.Installers
{
    public class CommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHandleMessages>().ImplementedBy<MessagesHandlerResolver>());
            container.Register(Classes.FromAssemblyContaining<IHandleMessages>().BasedOn(typeof(IHandleMessages<>)).WithServiceAllInterfaces());
        }
    }
}