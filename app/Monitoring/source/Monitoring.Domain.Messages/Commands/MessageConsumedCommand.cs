using System;

namespace Monitoring.Domain.Messages.Commands
{
    public interface MessageConsumedCommand
    {
        Guid AggregateId { get; set; }
        Guid EventId { get; set; }
        bool HasBeenConsumed { get; set; }

        //void Set(Guid aggregateId, Guid eventId);

        //void IsConsumed();
        //void IsNotConsumed();
    }
}
