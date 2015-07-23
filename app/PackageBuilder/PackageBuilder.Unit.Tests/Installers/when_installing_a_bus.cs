using MemBus;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_a_bus : BaseTestHelper
    {
        public override void Observe()
        {

        }

        [Observation]
        public void should_resolve_IBus()
        {
            Container.Resolve<IBus>().ShouldNotBeNull();
        }
    }
}