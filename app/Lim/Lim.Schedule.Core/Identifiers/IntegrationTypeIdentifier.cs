using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class IntegrationTypeIdentifier
    {
        [DataMember]
        public short Id { get; private set; }
        [DataMember]
        public string Type { get; private set; }

        public IntegrationTypeIdentifier(short id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
