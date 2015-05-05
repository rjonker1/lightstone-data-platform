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
            var bus = new TransactionBus(_bus);

            transaction = new InvoiceTransactionCreated(new Guid("7B0C9277-0CCA-42BB-ACFB-8E60D8D02B3F"));
            //transaction = new InvoiceTransactionCreated(new Guid("FD720634-2959-480A-BA45-96D970DA885C"));
            //bus.Send(transaction, "DataPlatform.Transactions.Billing", "DataPlatform.Transactions.Billing");
            bus.SendDynamic(transaction);
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}