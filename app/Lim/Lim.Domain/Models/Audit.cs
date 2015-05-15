using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class AuditPush
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long ConfigurationId { get; set; }
        [DataMember]
        public long IntegrationType { get; set; }
        [DataMember]
        public DateTime PushedDate { get; set; }
        [DataMember]
        public string Payload { get; set; }
    }

    [DataContract]
    public class AuditPull
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long ConfigurationId { get; set; }
        [DataMember]
        public long IntegrationType { get; set; }
        [DataMember]
        public DateTime PulledDate { get; set; }
        [DataMember]
        public string Payload { get; set; }
    }
}
