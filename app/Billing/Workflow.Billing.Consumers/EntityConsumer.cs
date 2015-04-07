using EasyNetQ.AutoSubscribe;
using Shared.Messaging.Billing.Messages;

namespace Workflow.Billing.Consumers
{
    public class EntityConsumer : IConsume<UserMessage>
    {
        public void Consume(UserMessage message)
        {
            var entity = message;
        }
    }
}