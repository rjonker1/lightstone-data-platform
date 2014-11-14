using System;
namespace EventTracking.Domain.Messages.Messages
{
    public class EventCommandHasBeenProcessed
    {
        public Guid AggregateId { get; set; }
        public Guid EventId { get; set; }
        public bool IsTrue { get; set; }
    }
}
