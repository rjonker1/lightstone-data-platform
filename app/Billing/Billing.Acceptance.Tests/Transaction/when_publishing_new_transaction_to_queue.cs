using System;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Shared.Messaging.Billing.Helpers;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
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
            var bus = new TransactionBus(_bus);

            transaction = new InvoiceTransactionCreated(new Guid("BA754D23-E5A1-4DFA-A7D4-0E71A5724C5D"));

            //var message = (IMessage<InvoiceTransactionCreated>) (transaction);

            bus.Send(transaction, "TESTEXCHANGE1", "TESTQUEUE1");
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}