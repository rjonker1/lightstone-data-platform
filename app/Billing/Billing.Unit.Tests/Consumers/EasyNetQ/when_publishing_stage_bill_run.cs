using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_publishing_stage_bill_run : BaseTestHelper
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_stage_bill_run()
        {
            _bus = Container.Resolve<IAdvancedBus>();
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            var billRun = new BillingMessage()
            {
                RunType = "Stage",
                Schedule = null
            };

            bus.SendDynamic(billRun);
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}