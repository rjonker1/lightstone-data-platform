using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Domain.Commands;

namespace PackageBuilder.Web.Plumbing.Windsor.Installers
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