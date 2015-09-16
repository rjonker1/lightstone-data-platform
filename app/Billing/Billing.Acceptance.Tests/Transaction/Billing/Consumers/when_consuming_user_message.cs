using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_user_message: BaseTestHelper
    {
        private readonly UserMessage _message;
        private Exception thrownException;

        public when_consuming_user_message()
        {
            _message = new UserMessage
            {
                Id = Guid.NewGuid(),
                Username = "Testeroonie",
                FirstName = "Test",
                LastName = "Roonie"
            };
        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<UserConsumer>().Consume(new Message<UserMessage>(_message));
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