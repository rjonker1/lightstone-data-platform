using System;

namespace Monitoring.Domain.Messages.Commands
{
    public interface MessageConsumedCommand
    {
        Guid AggregateId { get; }
        Guid EventId { get; }
        bool HasBeenConsumed { get; }

        void Set(Guid aggregateId, Guid eventId);

        void IsConsumed();
        void IsNotConsumed();
    }
}
