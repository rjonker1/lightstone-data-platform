using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class AuditIntegration
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public Guid ConfigurationKey { get; set; }

        [DataMember]
        public int ActionType { get; set; }

        [DataMember]
        public int IntegrationType { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public bool WasSuccessful { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Suffix { get; set; }

        [DataMember]
        public string Payload { get; set; }
    }
}