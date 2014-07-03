using System;
namespace Monitoring.Events.Lace
{
    public class ExternalSourceExecutedEvent : ExternalSourceBaseEvent
    {
        public ExternalSourceExecutedEvent(Guid id, Guid aggregateId, int source, string message, DateTime eventDate, string category, int order)
        {
            Id = id;
            AggregateId = aggregateId;
            SourceId = source;
            Message = message;
            EventDate = eventDate;
            Category = category;
            Order = order;
        }
    }
}
