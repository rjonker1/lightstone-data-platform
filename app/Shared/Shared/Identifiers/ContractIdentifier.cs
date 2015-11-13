using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
    public class ContractIdentifier
    {
          public ContractIdentifier()
        {
        }

          public ContractIdentifier(Guid id, VersionIdentifier version)
        {
            Id = id;
            Version = version;
        }

        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public VersionIdentifier Version { get; set; }
    }
}
