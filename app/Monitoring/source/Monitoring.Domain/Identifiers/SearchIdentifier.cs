using System;
using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [DataContract]
    public class SearchIdentifier
    {
        public SearchIdentifier() { }

        public SearchIdentifier(string packageName, long packageVersion, string elapsedTime, Guid requestId, int dataProviderCount)
        {
            PackageName = packageName;
            PackageVersion = packageVersion;
            ElapsedTime = elapsedTime;
            RequestId = requestId;
            DataProviderCount = dataProviderCount;
        }

        [DataMember]
        public Guid RequestId { get; private set; }
        [DataMember]
        public string PackageName { get; private set; }
        [DataMember]
        public long PackageVersion { get; private set; }
        [DataMember]
        public string ElapsedTime { get; private set; }
        [DataMember]
        public int DataProviderCount { get; private set; }
    }
}
