using System;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Extensions;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider.Events
{
    [DataContract]
    public class ExecutionEnded
    {
        public ExecutionEnded()
        {
            
        }

        public static ExecutionEnded Deserialize(string jsonPayload)
        {
            return string.IsNullOrEmpty(jsonPayload) ? new ExecutionEnded() : jsonPayload.JsonToObject<ExecutionEnded>() ?? new ExecutionEnded();
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
        public PayloadObject Payload { get; set; }
        [DataMember]
        public ConnectionPayload Connection { get; set; }
    }
}