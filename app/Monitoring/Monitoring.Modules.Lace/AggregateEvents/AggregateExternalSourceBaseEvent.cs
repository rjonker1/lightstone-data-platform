using System;

namespace Monitoring.Modules.Lace.AggregateEvents
{
    public class AggregateExternalSourceBaseEvent : IAggregateEvent
    {
        public Guid Id { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public string Source { get; protected set; }
        public string Message { get; protected set; }
        public DateTime EventDate { get; protected set; }
    }
}
