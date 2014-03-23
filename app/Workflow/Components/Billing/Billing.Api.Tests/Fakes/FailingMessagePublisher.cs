using System;
using DataPlatform.Shared.Public.Messaging;
using Workflow;

namespace Billing.Api.Tests.Fakes
{
    public class FailingMessagePublisher : IPublishMessages
    {
        public void Publish(IPublishableMessage message)
        {
            throw new Exception("I will always fail");
        }
    }
}