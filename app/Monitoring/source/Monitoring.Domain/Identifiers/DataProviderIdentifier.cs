using System;
using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [DataContract]
    public sealed class DataProviderIdentifier
    {
        public DataProviderIdentifier(Guid requestId, string packageName, string dataProviderName,
            short dataProviderId)
        {
            RequestId = requestId;
            PackageName = packageName;
            Name = dataProviderName;
            Id = dataProviderId;
        }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string PackageName { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public short Id { get; private set; }
    }
}