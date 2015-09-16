using System;
using Billing.TestHelper.BaseTests;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Messages.Publishable;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_stage_billing_cache_reload_message: BaseTestHelper
    {
        private readonly BillCacheMessage _billMessage;
        private BillRunConsumer _billRunConsumer;
        private Exception thrownException;

        public when_consuming_stage_billing_cache_reload_message()
        {
            _billMessage = new BillCacheMessage
            {
                BillingType = typeof(PreBilling),
                Command = BillingCacheCommand.Reload
            };

        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<BillCacheConsumer>().Consume(new Message<BillCacheMessage>(_billMessage));
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