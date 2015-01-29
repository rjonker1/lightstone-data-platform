using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    [DataContract]
    public class RgtVinExecutionStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public RgtVinExecutionStarted()
        {

        }

        public RgtVinExecutionStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class RgtVinExecutionEnded : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public RgtVinExecutionEnded()
        {

        }

        public RgtVinExecutionEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }


    [Serializable]
    [DataContract]
    public class RgtVinDataSourceCallStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public RgtVinDataSourceCallStarted()
        {

        }

        public RgtVinDataSourceCallStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class RgtVinDataSourceCallEnded : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public RgtVinDataSourceCallEnded()
        {

        }

        public RgtVinDataSourceCallEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class RgtVinSecurityFlagRisen : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public RgtVinSecurityFlagRisen()
        {

        }

        public RgtVinSecurityFlagRisen(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class RgtVinConfigured : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public RgtVinConfigured()
        {

        }

        public RgtVinConfigured(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class RgtVinResponseTransformed : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public RgtVinResponseTransformed()
        {

        }

        public RgtVinResponseTransformed(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }
}
