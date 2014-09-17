using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Domain.Helpers.Cqrs.CommandHandling;

namespace PackageBuilder.Domain.Helpers.Windsor.Installers
{
    public class CommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHandleCommand>().ImplementedBy<CommandHandler>());
            container.Register(Classes.FromAssemblyContaining<IHandleCommand>().BasedOn(typeof(IHandleCommand<>)).WithServiceAllInterfaces());
        }
    }
}