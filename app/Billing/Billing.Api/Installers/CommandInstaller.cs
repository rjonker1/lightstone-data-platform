using Billing.Domain.Core.MessageHandling;
using Billing.Domain.Entities;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;

namespace Billing.Api.Installers
{
    public class CommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install CommandInstaller");

            container.Register(Component.For<IHandleMessages>().ImplementedBy<MessageHandlerResolver>());
            container.Register(
                Classes.FromAssemblyContaining<CreateUpdateEntityHandler>()
                    .BasedOn(typeof(IHandleMessages<>))
                    .WithServiceAllInterfaces()
                    .LifestyleTransient());

            this.Info(() => "Successfully installed CommandInstaller");
        }
    }
}