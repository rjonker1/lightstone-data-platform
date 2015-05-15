using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class Actions
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }
    }


    [DataContract]
    public class IntegrationType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }
    }

    [DataContract]
    public class AuthenticationType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }
    }

    [DataContract]
    public class IntegrationPackages
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long ConfigurationId { get; set; }

        [DataMember]
        public Guid PackageId { get; set; }
    }
}