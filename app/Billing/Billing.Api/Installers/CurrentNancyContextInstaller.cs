using Billing.Api.Helpers.Nancy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Billing.Api.Installers
{
    public class CurrentNancyContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<CurrentNancyContext>().ImplementedBy<CurrentNancyContext>());
        }
    }
}