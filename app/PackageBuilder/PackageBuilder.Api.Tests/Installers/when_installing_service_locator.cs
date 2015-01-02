using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Installers
{
    public class when_installing_service_locator : Specification
    {
        readonly IWindsorContainer _container = new WindsorContainer();

        public override void Observe()
        {
            _container.Install(new ServiceLocatorInstaller());
        }

        [Observation]
        public void should_resolve_IServiceLocator()
        {
            _container.Resolve<IServiceLocator>().ShouldNotBeNull();
        }
    }
}