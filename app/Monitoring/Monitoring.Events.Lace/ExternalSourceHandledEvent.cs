using System;

namespace Monitoring.Events.Lace
{
    public class ExternalSourceHandledEvent : ExternalSourceBaseEvent
    {

        public ExternalSourceHandledEvent(Guid id, Guid aggregateId, string source, string message, DateTime eventDate)
        {
            Id = id;
            AggregateId = aggregateId;
            Source = source;
            Message = message;
            EventDate = eventDate;
        }
    }
}
