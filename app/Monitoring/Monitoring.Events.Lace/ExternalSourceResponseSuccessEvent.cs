using System;

namespace Monitoring.Events.Lace
{
    public class ExternalSourceResponseSuccessEvent : ExternalSourceBaseEvent
    {
        public ExternalSourceResponseSuccessEvent(Guid id, Guid aggregateId, int source, string message,
            DateTime eventDate, string payload, string category)
        {
            Id = id;
            AggregateId = aggregateId;
            SourceId = source;
            Message = message;
            EventDate = eventDate;
            Payload = payload;
            Category = category;
        }

        public string Payload { get; private set; }
    }
}
