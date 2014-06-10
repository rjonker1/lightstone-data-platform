using System;

namespace Monitoring.Consumer.Lace.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        Guid AggregateId { get; }
        string Source { get; }
        string Message { get; }
        DateTime EventDate { get; }
    }
}
