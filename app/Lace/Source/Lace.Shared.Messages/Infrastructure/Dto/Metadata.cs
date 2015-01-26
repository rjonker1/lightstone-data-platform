using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Infrastructure.Dto
{
    [Serializable]
    [DataContract]
    public class MetadataContainer
    {
        [DataMember]
        public object Metadata { get; private set; }

        [DataMember]
        public bool HasMetaData { get; private set; }

        public MetadataContainer()
        {
            HasMetaData = false;
        }

        public MetadataContainer(object metadata)
        {
            HasMetaData = metadata != null;
            Metadata = metadata;
        }
    }

    [Serializable]
    [DataContract]
    public class PerformanceMetadata
    {
        [DataMember]
        public object Results { get; private set; }

        [DataMember]
        public bool HasResults { get; private set; }

        public PerformanceMetadata()
        {
            HasResults = false;
        }

        public PerformanceMetadata(object results)
        {
            HasResults = results != null;
            Results = results;
        }
    }
}
