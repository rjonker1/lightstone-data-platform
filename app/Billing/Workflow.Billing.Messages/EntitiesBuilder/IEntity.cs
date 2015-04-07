using System;

namespace Workflow.Billing.Messages.EntitiesBuilder
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}