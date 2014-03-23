using DataPlatform.Shared.Public.Messaging;
using Workflow;

namespace Billing.Api.Tests.Fakes
{
    public class TestMessagePublisher : IPublishMessages
    {
        public IPublishableMessage PublishedMessage { get; private set; }

        public void Publish(IPublishableMessage message)
        {
            PublishedMessage = message;
        }
    }
}
