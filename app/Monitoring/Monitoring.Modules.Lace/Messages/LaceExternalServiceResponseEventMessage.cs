using System;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Messages
{
    public class LaceExternalServiceResponseEventMessage : ITrackExternalSourceEventMessage
    {

        public LaceExternalServiceResponseEventMessage(Guid aggregateId, FromSource source, string message)
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
        public FromSource Source { get; private set; }
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
