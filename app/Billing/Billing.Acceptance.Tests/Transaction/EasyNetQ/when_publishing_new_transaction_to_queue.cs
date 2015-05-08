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

            //Customer
            transaction = new InvoiceTransactionCreated(new Guid("CA17F55B-F068-4DE0-B614-6A1F29EE4313"));

            ////Client
            //transaction = new InvoiceTransactionCreated(new Guid("FD720634-2959-480A-BA45-96D970DA885C"));
            bus.SendDynamic(transaction);
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}