using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_client_message: BaseTestHelper
    {
        private readonly ClientMessage _message;
        private Exception thrownException;

        public when_consuming_client_message()
        {
            _message = new ClientMessage
            {
                Id = Guid.NewGuid(),
                AccountNumber = "Tes001",
                AccountOwner = "Testeroonie",
                ClientId = Guid.NewGuid(),
                ClientName = "Teseroonie Inc",
                BillingType = "BILLABLE"
            };
        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<ClientConsumer>().Consume(new Message<ClientMessage>(_message));
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