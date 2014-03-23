using DataPlatform.Shared.Public.Messaging;
using Workflow;

namespace Billing.Api.Tests.Fakes
{
    public class TestMessagePublisher : IPublishMessages
    {
        public IPublishableMessage PublishedMessage { get; private set; }

        public void Publish<TMessage>(TMessage message) where TMessage : IPublishableMessage
        {
            PublishedMessage = message;
        }
    }
}
