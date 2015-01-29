using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    [DataContract]
    public class LightstoneExecutionStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public LightstoneExecutionStarted()
        {

        }

        public LightstoneExecutionStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class LightstoneExecutionEnded : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public LightstoneExecutionEnded()
        {

        }

        public LightstoneExecutionEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }


    [Serializable]
    [DataContract]
    public class LightstoneDataSourceCallStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public LightstoneDataSourceCallStarted()
        {

        }

        public LightstoneDataSourceCallStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class LightstoneDataSourceCallEnded : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public LightstoneDataSourceCallEnded()
        {

        }

        public LightstoneDataSourceCallEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class LightstoneSecurityFlagRisen : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public LightstoneSecurityFlagRisen()
        {

        }

        public LightstoneSecurityFlagRisen(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class LightstoneConfigured : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public LightstoneConfigured()
        {

        }

        public LightstoneConfigured(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class LightstoneResponseTransformed : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public LightstoneResponseTransformed()
        {

        }

        public LightstoneResponseTransformed(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }
}
