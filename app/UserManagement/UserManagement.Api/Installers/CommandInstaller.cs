using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Domain.CommandHandlers.Entities;
using UserManagement.Domain.Core.MessageHandling;

namespace UserManagement.Api.Installers
{
    public class CommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHandleMessages>().ImplementedBy<MessageHandlerResolver>());
            container.Register(
                Classes.FromAssemblyContaining<CreateUpdateEntityHandler>()
                    .BasedOn(typeof (IHandleMessages<>))
                    .WithServiceAllInterfaces()
                    .LifestyleTransient());
        }
    }
}