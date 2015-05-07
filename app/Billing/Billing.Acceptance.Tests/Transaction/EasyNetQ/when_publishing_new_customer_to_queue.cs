using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.EasyNetQ
{
    public class when_publishing_new_customer_to_queue : Specification
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_customer_to_queue()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            var customer = new CustomerMessage()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                CreatedBy = "UNITTEST",
                AccountNumber = "UNITTEST0001",
                BillingType = "Response",
                CustomerId = new Guid("662872BB-38DF-4436-87A8-E4D45B6DD70B"),
                CustomerName = "Customer 1"
            };

            bus.SendDynamic(customer);
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}