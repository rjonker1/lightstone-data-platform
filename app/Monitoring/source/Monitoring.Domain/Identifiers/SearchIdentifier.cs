using System;
using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [Serializable]
    [DataContract]
    public class SearchIdentifier
    {
        public SearchIdentifier() { }

        public SearchIdentifier(string searchType, string searchTerm, string elapsedTime, Guid requestId, string bucketId)
        {
            SearchType = searchType;
            SearchTerm = searchTerm;
            ElapsedTime = elapsedTime;
            RequestId = requestId;
            BucketId = bucketId;
        }

        [DataMember]
        public Guid RequestId { get; private set; }
        [DataMember]
        public string BucketId { get; private set; }
        [DataMember]
        public string SearchType { get; private set; }
        [DataMember]
        public string SearchTerm { get; private set; }
        [DataMember]
        public string ElapsedTime { get; private set; }
    }
}
