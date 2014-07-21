using System;
using DataPlatform.Shared.Helpers;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class BaseEventMessage : IMonitorExternalSourceEventMessage
    {
        public BaseEventMessage(Guid aggregateId, LaceEventSource source, string message, int order,
            string category)
        {
            AggregateId = aggregateId;
            Message = message;
            Source = source;
            Order = order;
            Category = category;

            Id = Guid.NewGuid();
            EventDate = SystemTime.Now();
        }

        public Guid Id { get; private set; }

        public Guid AggregateId { get; private set; }
        public LaceEventSource Source { get; private set; }
        public string Message { get; private set; }
        public string Category { get; private set; }
        public int Order { get; private set; }

        public DateTime EventDate { get; private set; }
    }
}

