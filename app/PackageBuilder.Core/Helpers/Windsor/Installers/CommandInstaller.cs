using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Core.Helpers.MessageHandling;

namespace PackageBuilder.Core.Helpers.Windsor.Installers
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
