using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Messages.Infrastructure
{
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

    [DataContract]
    public class PerformanceMetadata
    {
        [DataMember]
        public StopWatchResults Results { get; private set; }

        [DataMember]
        public bool HasResults { get; private set; }

        public PerformanceMetadata()
        {
            HasResults = false;
        }

        public PerformanceMetadata(StopWatchResults results)
        {
            HasResults = results != null;
            Results = results;
        }
    }
}
