using Microsoft.Practices.ServiceLocation;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_service_locator : BaseTestHelper
    {

        public override void Observe()
        {
            
        }

        [Observation]
        public void should_resolve_IServiceLocator()
        {
            Container.Resolve<IServiceLocator>().ShouldNotBeNull();
        }
    }
}