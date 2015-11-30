using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [DataContract]
    public sealed class RequestFieldIdentifier
    {
        public RequestFieldIdentifier(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string Value { get; private set; }
    }
}