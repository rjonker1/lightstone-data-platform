using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Shared.Logging;
using Workflow.BuildingBlocks;

namespace Workflow.Billing.Helpers.Schedules
{
    public class MessageSchedule
    {
        IAdvancedBus _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");

        public void Send(BillingMessage message)
        {
            this.Info(() => "Attempting to send BillingMessage: {0} to queue.".FormatWith(message.RunType));
            var bus = new TransactionBus(_bus);
            bus.SendDynamic(new BillingMessage() { RunType = message.RunType, Schedule = message.Schedule });
            this.Info(() => "Successfully sent BillingMessage: {0} to queue.".FormatWith(message.RunType));
        }
    }
}