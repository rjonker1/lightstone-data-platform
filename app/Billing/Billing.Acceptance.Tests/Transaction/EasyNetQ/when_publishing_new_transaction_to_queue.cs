using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.EasyNetQ
{
    public class when_publishing_new_transaction_to_queue : Specification
    {
        private readonly IAdvancedBus _bus;
        private InvoiceTransactionCreated transaction;

        public when_publishing_new_transaction_to_queue()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
        }

        public override void Observe()
        {

        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            var bus = new TransactionBus(_bus);

            // Customer
            transaction = new InvoiceTransactionCreated(new Guid("4B905242-4352-4A36-B1CD-CF6832606703"));

            bus.SendDynamic(transaction);

            _bus.ShouldNotBeNull();
        }
    }
}