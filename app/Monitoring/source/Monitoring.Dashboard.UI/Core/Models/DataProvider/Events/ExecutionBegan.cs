using System;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Extensions;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider.Events
{
    [DataContract]
    public class ExecutionBegan
    {
        public ExecutionBegan()
        {
            
        }

        public static ExecutionBegan Deserialize(string jsonPayload)
        {
            var obj  =  string.IsNullOrEmpty(jsonPayload) ? new ExecutionBegan() : jsonPayload.JsonToObject<ExecutionBegan>() ?? new ExecutionBegan();
            return obj;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; set; }

        [DataMember]
        public DataProvider DataProvider { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public RequestDetailsPayload Payload { get; set; }
        [DataMember]
        public ConnectionPayload Connection { get; set; }
    }
}