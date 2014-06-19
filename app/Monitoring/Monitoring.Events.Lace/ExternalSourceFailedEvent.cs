using System;

namespace Monitoring.Events.Lace
{
    public class ExternalSourceFailedEvent : ExternalSourceBaseEvent
    {
        public ExternalSourceFailedEvent(Guid id, Guid aggregateId, int source, string message, DateTime eventDate, string category)
        {
            Id = id;
            AggregateId = aggregateId;
            SourceId = source;
            Message = message;
            EventDate = eventDate;
            Category = category;
        }
    }
}
