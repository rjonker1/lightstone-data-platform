using System;
using System.Runtime.Serialization;
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
    [DataContract]
    public class MonitoringEvent : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
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
