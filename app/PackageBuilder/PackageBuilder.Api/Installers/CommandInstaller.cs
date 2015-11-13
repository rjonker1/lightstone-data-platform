using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.CommandHandlers.DataProviders;

namespace PackageBuilder.Api.Installers
{
    public class CommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHandleMessages>().ImplementedBy<MessagesHandlerResolver>());
            container.Register(Classes.FromAssemblyContaining<CreateDataProviderHandler>().BasedOn(typeof(IHandleMessages<>)).WithServiceAllInterfaces().LifestyleTransient());
        }
    }
}
