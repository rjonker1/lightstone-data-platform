using Xunit.Extensions;

namespace Workflow.Billing.Consumer.Tests
{
    public class PlaceHolderTest : Specification
    {
        public override void Observe()
        {
        }

        [Observation]
        public void start_implementing_tests()
        {
            true.ShouldBeTrue();
        }
    }
}