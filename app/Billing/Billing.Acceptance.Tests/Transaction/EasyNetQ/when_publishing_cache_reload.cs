using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Messages.Publishable;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.EasyNetQ
{
    public class when_publishing_cache_reload: Specification
    {
        private readonly IAdvancedBus _bus;
        private TransactionBus advancedBus;

        public when_publishing_cache_reload()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
        }

        public override void Observe()
        {
            advancedBus = new TransactionBus(_bus);
        }

        [Observation]
        public void should_publish_message_for_preBilling()
        {
            advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(PreBilling), Command = BillingCacheCommand.Reload });
        }

        [Observation]
        public void should_publish_message_for_stageBilling()
        {
            advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(StageBilling), Command = BillingCacheCommand.Reload });
        }

        [Observation]
        public void should_publish_message_for_finalBilling()
        {
            advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(FinalBilling), Command = BillingCacheCommand.Reload });
        }
    }
}