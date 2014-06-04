using System;

namespace Monitoring.Consumer.Lace.Events
{
    public class ExternalSourceRequestSentEvent : ExternalSourceBaseEvent
    {
        public ExternalSourceRequestSentEvent(Guid id, Guid aggregateId, string source, string message,
            DateTime eventDate)
        {
            Id = id;
            AggregateId = aggregateId;
            Source = source;
            Message = message;
            EventDate = eventDate;
        }
    }
}
