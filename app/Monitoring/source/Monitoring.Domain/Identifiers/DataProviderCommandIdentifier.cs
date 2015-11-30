using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [DataContract]
    public class DataProviderCommandIdentifier
    {
        public DataProviderCommandIdentifier(short id, string name)
        {
            Name = name;
            Id = id;
        }

        [DataMember]
        public short Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }
    }
}