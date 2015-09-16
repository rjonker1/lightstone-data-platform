using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_stage_billing_run_message : BaseTestHelper
    {
        private readonly BillingMessage _billMessage;
        private BillRunConsumer _billRunConsumer;
        private Exception thrownException;

        public when_consuming_stage_billing_run_message()
        {
            _billMessage = new BillingMessage
            {
                Id = Guid.NewGuid(),
                RunType = "Stage",
                Schedule = null
            };

        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<BillRunConsumer>().Consume(new Message<BillingMessage>(_billMessage));
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void should_consume_message()
        {
            thrownException.ShouldBeNull();
        }
    }
}