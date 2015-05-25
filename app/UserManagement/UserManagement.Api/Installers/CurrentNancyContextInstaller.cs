using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Api.Helpers.Nancy;

namespace UserManagement.Api.Installers
{
    public class CurrentNancyContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<CurrentNancyContext>().ImplementedBy<CurrentNancyContext>());
        }
    }
}