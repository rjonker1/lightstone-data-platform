using System;
using Lace.Shared.Enums;

namespace Lace.Events.Messages
{
    public class LaceExternalServiceResponseEventMessage : ILaceEventMessage
    {

        public LaceExternalServiceResponseEventMessage(Guid aggregateId, EventSource source, string message)
        {
            AggregateId = aggregateId;
            Message = message;
            Source = source;
        }

        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public Guid AggregateId { get; private set; }
        public EventSource Source { get; private set; }
        public string Message { get; private set; }

        public DateTime EventDate
        {
            get
            {
                return DateTime.UtcNow;
            }
        } 
    }
}
