using System;
namespace Monitoring.Modules.Lace.AggregateEvents
{
    public class AggregateExternalSourceEvent : AggregateExternalSourceBaseEvent
    {
        public AggregateExternalSourceEvent(Guid id, Guid aggregateId, string source, string message, DateTime eventDate)
        {
            Id = id;
            AggregateId = aggregateId;
            Source = source;
            Message = message;
            EventDate = eventDate;
        }
    }

    //public class ExternalSourceEvent : IAggregateEvent
    //{

    //    public ExternalSourceEvent(Guid id, Guid aggregateId, string source, string message, DateTime eventDate)
    //    {
    //        Id = id;
    //        AggregateId = aggregateId;
    //        Source = source;
    //        Message = message;
    //        EventDate = eventDate;
    //    }

    //    public Guid Id { get; private set; }
    //    public Guid AggregateId { get; private set; }
    //    public string Source { get; private set; }
    //    public string Message { get; private set; }
    //    public DateTime EventDate { get; private set; }
    //}
}
