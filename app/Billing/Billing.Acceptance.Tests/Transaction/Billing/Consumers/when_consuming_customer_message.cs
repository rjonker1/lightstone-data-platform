using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_customer_message: BaseTestHelper
    {
        private readonly CustomerMessage _message;
        private Exception thrownException;

        public when_consuming_customer_message()
        {
            _message = new CustomerMessage
            {
                Id = Guid.NewGuid(),
                AccountNumber = "Tes002",
                AccountOwner = "Testeroonie",
                CustomerId = Guid.NewGuid(),
                CustomerName = "Teseroonie Inc CUS",
                BillingType = "BILLABLE"
            };
        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<CustomerConsumer>().Consume(new Message<CustomerMessage>(_message));
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void should_consume_message()
        {
            thrownException.ShouldBeNull();
        }
    }
}