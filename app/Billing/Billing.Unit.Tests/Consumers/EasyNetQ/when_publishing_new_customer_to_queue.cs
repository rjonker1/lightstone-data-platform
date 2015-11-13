using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_publishing_new_customer_to_queue : BaseTestHelper
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_customer_to_queue()
        {
            _bus = Container.Resolve<IAdvancedBus>();
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