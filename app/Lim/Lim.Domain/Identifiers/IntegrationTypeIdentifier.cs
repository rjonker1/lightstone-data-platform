using System.Runtime.Serialization;

namespace Lim.Domain.Identifiers
{
    [DataContract]
    public class IntegrationTypeIdentifier
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Type { get; private set; }

        public IntegrationTypeIdentifier(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
