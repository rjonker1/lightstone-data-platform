using System;
using DataPlatform.Shared.Public.Helpers;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceExternalSourceRequestEventMessage : ITrackExternalSourceEventMessage
    {

        public LaceExternalSourceRequestEventMessage(Guid aggregateId, LaceEventSource source, string message, string payload)
        {
            AggregateId = aggregateId;
            Message = message;
            Source = source;
            Payload = payload;
        }

        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public Guid AggregateId { get; private set; }
        public LaceEventSource Source { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }

        public DateTime EventDate
        {
            get
            {
                return SystemTime.Now();
            }
        } 
    }
}
