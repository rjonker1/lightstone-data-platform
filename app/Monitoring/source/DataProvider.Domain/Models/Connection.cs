using System.Runtime.Serialization;

namespace DataProvider.Domain.Models
{
    [DataContract]
    public class ConnectionPayload
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Connection { get; set; }
    }
}