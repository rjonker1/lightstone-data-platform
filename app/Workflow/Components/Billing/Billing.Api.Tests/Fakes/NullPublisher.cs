using DataPlatform.Shared.Public.Messaging;
using Workflow;

namespace Billing.Api.Tests.Fakes
{
    public class NullPublisher : IPublishMessages
    {
        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
        }
    }
}