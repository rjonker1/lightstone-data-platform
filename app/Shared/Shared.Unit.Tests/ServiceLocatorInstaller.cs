using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;

namespace Shared.Unit.Tests
{
    public class ServiceLocatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Setup Microsoft Practices service locator for any components that require it
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            //Register the service locator interface for any components that require it
            container.Register(Component.For<IServiceLocator>().Instance(ServiceLocator.Current).LifestyleTransient());
        }
    }
}