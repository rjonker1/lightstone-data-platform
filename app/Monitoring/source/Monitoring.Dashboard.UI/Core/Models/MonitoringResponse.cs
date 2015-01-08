using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [Serializable]
    [DataContract]
    public class MonitoringResponse
    {
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public string Payload { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }

        public MonitoringResponse(Guid id, string payload, DateTime date)
        {
            Id = id;
            Payload = payload;
            Date = date;
        }
    }
}