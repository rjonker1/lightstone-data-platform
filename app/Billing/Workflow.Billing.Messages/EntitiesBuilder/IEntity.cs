using System;
using DataPlatform.Shared.Messaging;

namespace Workflow.Billing.Messages.EntitiesBuilder
{
    public interface IEntity : IPublishableMessage
    {
        Guid Id { get; }
    }
}