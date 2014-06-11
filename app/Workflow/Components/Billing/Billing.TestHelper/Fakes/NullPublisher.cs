using DataPlatform.Shared.Public.Messaging;
using Workflow;

namespace Billing.TestHelper.Fakes
{
    public class NullPublisher : IPublishMessages
    {
        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
        }
    }
}