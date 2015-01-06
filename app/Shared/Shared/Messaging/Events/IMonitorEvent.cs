using System;
namespace DataPlatform.Shared.Messaging.Events
{
    interface IMonitorEvent : IPublishableMessage
    {
        Guid AggregateId { get; }
        DateTime Date { get; }
        string Payload { get; }
    }

    [Serializable]
    public class MonitoringEvent : IMonitorEvent
    {
        public Guid AggregateId { get; private set; }
        public DateTime Date { get; private set; }
        public string Payload { get; private set; }

        public MonitoringEvent()
        {

        }

        public MonitoringEvent(Guid aggregateId, string payload, DateTime date)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
        }
    }
}
