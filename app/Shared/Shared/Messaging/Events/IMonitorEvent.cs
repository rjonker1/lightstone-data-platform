using System;
using DataPlatform.Shared.Enums;

namespace DataPlatform.Shared.Messaging.Events
{
    public interface IMonitorEvent : IPublishableMessage
    {
        Guid AggregateId { get; }
        DateTime Date { get; }
        string Payload { get; }
        MonitoringSource Source { get; }
    }

    [Serializable]
    public class MonitoringEvent : IMonitorEvent
    {
        public Guid AggregateId { get; private set; }
        public DateTime Date { get; private set; }
        public string Payload { get; private set; }
        public MonitoringSource Source { get; private set; }

        public MonitoringEvent()
        {

        }

        public MonitoringEvent(Guid aggregateId, string payload, DateTime date,MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }
}
