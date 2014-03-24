using System;
using DataPlatform.Shared.Public.Messaging;
using Workflow;

namespace Billing.Api.Tests.Fakes
{
    public class FailingMessagePublisher : IPublishMessages
    {
        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            throw new Exception("I will always fail");
        }
    }
}