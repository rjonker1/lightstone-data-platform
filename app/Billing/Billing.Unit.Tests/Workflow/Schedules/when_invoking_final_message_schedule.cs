using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using Workflow.Billing.Helpers.Schedules;
using Xunit.Extensions;

namespace Billing.Api.Tests.Workflow.Schedules
{
    public class when_invoking_final_message_schedule : BaseTestHelper
    {
        private BillingMessage billingMessage;
        private Exception thrownException;

        public override void Observe()
        {
            billingMessage = new BillingMessage
            {
                Id = Guid.NewGuid(),
                RunType = "Final"
            };

            try
            {
                new MessageSchedule().Send(billingMessage);
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