using System.Runtime.Serialization;

namespace DataPlatform.Shared.Dtos
{
    [DataContract]
    public class RequestFieldDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string Type { get; set; }
    }
}