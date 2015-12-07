using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;
using Shared.Logging;
using Workflow.Billing.Messages.Publishable;
using Workflow.BuildingBlocks.Builders;

namespace Workflow.Billing.Domain.Schedules
{
    public class CacheSchedule
    {
        IAdvancedBus _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");

        public void Send(BillCacheMessage message)
        {
            this.Info(() => "Attempting to send BillCacheMessage: {0} to queue.".FormatWith(message.BillingType));
            var bus = new TransactionBus(_bus);
            bus.SendDynamic(new BillCacheMessage { BillingType = message.BillingType, Command = message.Command });
            this.Info(() => "Successfully sent BillCacheMessage: {0} to queue.".FormatWith(message.BillingType));
        }
    }
}