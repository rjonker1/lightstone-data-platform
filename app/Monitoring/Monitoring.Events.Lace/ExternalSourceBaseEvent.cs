using System;

namespace Monitoring.Events.Lace
{
    public class ExternalSourceBaseEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public int SourceId { get; protected set; }
        public string Message { get; protected set; }
        public DateTime EventDate { get; protected set; }
        public string Category { get; protected set; }
    }
}
