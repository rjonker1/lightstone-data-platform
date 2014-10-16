using System;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IDomainEvent
    {
        String Id { get; }
        String AggregateId { get; }
        Int32 AggregateVersion { get; }
        DateTimeOffset OccurredAt { get; }
    }
}