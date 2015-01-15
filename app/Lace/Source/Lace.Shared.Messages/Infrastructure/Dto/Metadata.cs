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
}
