using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Shared.Logging;
using Workflow.BuildingBlocks.Builders;

namespace Workflow.Billing.Domain.Schedules
{
    public class CleanupSchedule
    {
        IAdvancedBus _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");

        public void Send(TransactionRequestCleanupMessage message)
        {
            this.Info(() => "Attempting to send TransactionRequestCleanupMessage: {0} to queue.".FormatWith(message));
            var bus = new TransactionBus(_bus);
            bus.SendDynamic(new TransactionRequestCleanupMessage());
            this.Info(() => "Successfully sent TransactionRequestCleanupMessage: {0} to queue.".FormatWith(message));
        } 
    }
}