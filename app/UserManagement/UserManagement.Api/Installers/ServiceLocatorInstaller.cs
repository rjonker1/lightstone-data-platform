using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using DataPlatform.Shared.Helpers.Extensions;
using Microsoft.Practices.ServiceLocation;

namespace UserManagement.Api.Installers
{
    public class ServiceLocatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install ServiceLocatorInstaller");

            //Setup Microsoft Practices service locator for any components that require it
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            //Register the service locator interface for any components that require it
            container.Register(Component.For<IServiceLocator>().Instance(ServiceLocator.Current).LifestyleTransient());

            this.Info(() => "Successfully installed ServiceLocatorInstaller");
        }
    }
}