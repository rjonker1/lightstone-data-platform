using System;
using DataPlatform.Shared.Public.Helpers;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceTransformResponseEventMessage : IMonitorExternalSourceEventMessage
    {
        public LaceTransformResponseEventMessage(Guid aggregateId, LaceEventSource source, string message)
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
        public LaceEventSource Source { get; private set; }
        public string Message { get; private set; }

        public DateTime EventDate
        {
            get
            {
                return SystemTime.Now();
            }
        }

        public string Category
        {
            get { return "laceExternalSourceTransformation"; }
        }
    }
}
