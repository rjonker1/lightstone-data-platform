using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.EasyNetQ
{
    public class when_publishing_stage_bill_run : Specification
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_stage_bill_run()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
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