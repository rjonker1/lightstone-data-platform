using System;
using DataPlatform.Shared.Helpers;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceEventMessage : IMonitorExternalSourceEventMessage
    {
        public LaceEventMessage(Guid aggregateId, LaceEventSource source, string message)
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
            get { return "lace"; }
        }
    }
}
