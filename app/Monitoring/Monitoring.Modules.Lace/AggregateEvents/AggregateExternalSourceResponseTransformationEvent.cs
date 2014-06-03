using System;

namespace Monitoring.Modules.Lace.AggregateEvents
{
    public class AggregateExternalSourceResponseTransformationEvent : AggregateExternalSourceBaseEvent
    {
        public AggregateExternalSourceResponseTransformationEvent(Guid id, Guid aggregateId, string source,
            string message,
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
