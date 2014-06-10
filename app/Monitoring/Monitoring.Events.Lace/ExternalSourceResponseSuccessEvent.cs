using System;

namespace Monitoring.Events.Lace
{
    public class ExternalSourceResponseSuccessEvent : ExternalSourceBaseEvent
    {
        public ExternalSourceResponseSuccessEvent(Guid id, Guid aggregateId, string source, string message,
            DateTime eventDate, string payload)
        {
            Id = id;
            AggregateId = aggregateId;
            Source = source;
            Message = message;
            EventDate = eventDate;
            Payload = payload;
        }

        public string Payload { get; private set; }
    }
}
