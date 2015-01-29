using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    [DataContract]
    public class ErrorThrown : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public MonitoringSource Source { get; private set; }

        public ErrorThrown()
        {

        }

        public ErrorThrown(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }
}
