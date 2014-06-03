using System;

namespace Monitoring.Modules.Lace.AggregateEvents
{
    public interface IAggregateEvent
    {
        Guid Id { get; }
        Guid AggregateId { get; }
        string Source { get; }
        string Message { get; }
        DateTime EventDate { get; }
    }
}
