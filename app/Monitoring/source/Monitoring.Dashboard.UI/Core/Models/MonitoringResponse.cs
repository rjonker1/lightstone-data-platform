using System;
using System.Runtime.Serialization;
using Microsoft.SqlServer.Server;

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

        [DataMember]
        public string Metadata { get; private set; }

        [DataMember]
        public bool HasErrors { get; private set; }

        [DataMember]
        public bool HasPerformanceData { get; private set; }

        [DataMember]
        public string PeformanceData { get; private set; }

        public MonitoringResponse()
        {
            
        }

        public MonitoringResponse(Guid id, string payload, DateTime date)
        {
            Id = id;
            Payload = payload;
            Date = date;
        }

        public void SetMetadata(string metadata)
        {
            Metadata = metadata;
        }

        public void RemovePayload()
        {
            Payload = string.Empty;
        }

        public void ErrorsExist()
        {
            HasErrors = true;
        }

        public void SetPerformanceData(string performanceData)
        {
            HasPerformanceData = !string.IsNullOrEmpty(performanceData);
            PeformanceData = performanceData;
        }
    }
}