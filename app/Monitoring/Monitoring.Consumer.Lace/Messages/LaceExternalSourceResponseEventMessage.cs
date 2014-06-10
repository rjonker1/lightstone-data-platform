using System;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceExternalSourceResponseEventMessage : ITrackExternalSourceEventMessage
    {

        public LaceExternalSourceResponseEventMessage(Guid aggregateId, FromSource source, string message,
            string payload)
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
        public FromSource Source { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }

        public DateTime EventDate
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
