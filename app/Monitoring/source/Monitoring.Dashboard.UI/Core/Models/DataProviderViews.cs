using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [DataContract]
    public class PackageInformation
    {
        [DataMember]
        public EntryPointReceivedRequest EntryPointReceivedRequest { get; set; }
    }

    [DataContract]
    public class EntryPointReceivedRequest
    {
        [DataMember]
        public Payload Payload { get; set; }
    }

    [DataContract]
    public class Payload
    {
        [DataMember]
        public Request Request { get; set; }
    }

    [DataContract]
    public class Request
    {
        [DataMember]
        public Package Package { get; set; }
        [DataMember]
        public string SearchTerm { get; set; }
        [DataMember]
        public string RequestDate { get; set; }
    }

    [DataContract]
    public class Package
    {
        [DataMember]
        public string Name { get; set; }
    }
}