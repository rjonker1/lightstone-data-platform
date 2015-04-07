using System;

namespace Shared.Messaging.Billing.Messages
{
    public interface IEntity
    {
        Guid Id { get; } 
    }
}