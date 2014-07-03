using System;

namespace EventTracking.Measurement.Lace.Events
{
    public interface IShowEventsPublishedForLaceRequests
    {
       // Guid Id { get; set; }
        Guid AggregateId { get; set; }
        string SourceId { get; set; }
        string Message { get; set; }
        DateTime TimeStamp { get; set; }
    }
}