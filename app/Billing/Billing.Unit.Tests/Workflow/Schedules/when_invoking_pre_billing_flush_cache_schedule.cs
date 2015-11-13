using System;
using Billing.TestHelper.BaseTests;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Helpers.Schedules;
using Workflow.Billing.Messages.Publishable;
using Xunit.Extensions;

namespace Billing.Api.Tests.Workflow.Schedules
{
    public class when_invoking_pre_billing_flush_cache_schedule : BaseTestHelper
    {
        private BillCacheMessage billCacheMessage;
        private Exception thrownException;

        public override void Observe()
        {
            billCacheMessage = new BillCacheMessage
            {
                BillingType = typeof(PreBilling),
                Command = BillingCacheCommand.Flush
            };

            try
            {
                new CacheSchedule().Send(billCacheMessage);
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void should_send_message_schedule()
        {
            thrownException.ShouldBeNull();
        }
    }
}