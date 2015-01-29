using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    [DataContract]
    public class AudatexExecutionStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public AudatexExecutionStarted()
        {

        }

        public AudatexExecutionStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class AudatexExecutionEnded : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public AudatexExecutionEnded()
        {

        }

        public AudatexExecutionEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }


    [Serializable]
    [DataContract]
    public class AudatexDataSourceCallStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public AudatexDataSourceCallStarted()
        {

        }

        public AudatexDataSourceCallStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class AudatexDataSourceCallEnded : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public AudatexDataSourceCallEnded()
        {

        }

        public AudatexDataSourceCallEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class AudatexSecurityFlagRisen : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public AudatexSecurityFlagRisen()
        {

        }

        public AudatexSecurityFlagRisen(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class AudatexConfigured : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public AudatexConfigured()
        {

        }

        public AudatexConfigured(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class AudatexResponseTransformed : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public AudatexResponseTransformed()
        {

        }

        public AudatexResponseTransformed(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }
}
