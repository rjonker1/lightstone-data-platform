using DataPlatform.Shared.Messaging;
using Workflow;

namespace Billing.TestHelper.Fakes
{
    public class TestMessagePublisher : IPublishMessages
    {
        public IPublishableMessage PublishedMessage { get; private set; }

        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            PublishedMessage = message;
        }
    }
}
