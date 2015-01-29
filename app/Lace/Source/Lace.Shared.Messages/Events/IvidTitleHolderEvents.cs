using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    [DataContract]
    public class IvidTitleHolderExecutionStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public IvidTitleHolderExecutionStarted()
        {

        }

        public IvidTitleHolderExecutionStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderExecutionEnded : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public IvidTitleHolderExecutionEnded()
        {

        }

        public IvidTitleHolderExecutionEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }


    [Serializable]
    [DataContract]
    public class IvidTitleHolderDataSourceCallStarted : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public IvidTitleHolderDataSourceCallStarted()
        {

        }

        public IvidTitleHolderDataSourceCallStarted(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderDataSourceCallEnded : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public IvidTitleHolderDataSourceCallEnded()
        {

        }

        public IvidTitleHolderDataSourceCallEnded(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderSecurityFlagRisen : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public IvidTitleHolderSecurityFlagRisen()
        {

        }

        public IvidTitleHolderSecurityFlagRisen(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderConfigured : IMonitorEvent
    {
       [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public IvidTitleHolderConfigured()
        {

        }

        public IvidTitleHolderConfigured(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderResponseTransformed : IMonitorEvent
    {
        [DataMember]
        public Guid AggregateId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public MonitoringSource Source { get; private set; }
       
        public IvidTitleHolderResponseTransformed()
        {

        }

        public IvidTitleHolderResponseTransformed(Guid aggregateId, string payload, DateTime date, MonitoringSource source)
        {
            AggregateId = aggregateId;
            Payload = payload;
            Date = date;
            Source = source;
        }
    }
}
