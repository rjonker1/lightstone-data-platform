using System;
using DataPlatform.Shared.Messaging;
using Workflow;

namespace Billing.TestHelper.Fakes
{
    public class FailingMessagePublisher : IPublishMessages
    {
        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            throw new Exception("I will always fail");
        }
    }
}