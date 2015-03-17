using System;

namespace Billing.Domain.Core.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}