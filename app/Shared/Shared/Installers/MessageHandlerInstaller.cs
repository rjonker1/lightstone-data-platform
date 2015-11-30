using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging;

namespace DataPlatform.Shared.Installers
{
    public class MessageHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install MessageHandlerInstaller");

            container.Register(Component.For<IHandleMessages>().ImplementedBy<MessageHandlerResolver>());

            this.Info(() => "Successfully installed MessageHandlerInstaller");
        }
    }
}