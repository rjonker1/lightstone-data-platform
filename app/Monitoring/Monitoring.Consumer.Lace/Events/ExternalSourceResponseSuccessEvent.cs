using System;

namespace Monitoring.Consumer.Lace.Events
{
    public class ExternalSourceResponseSuccessEvent : ExternalSourceBaseEvent
    {
        public ExternalSourceResponseSuccessEvent(Guid id, Guid aggregateId, string source, string message,
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
