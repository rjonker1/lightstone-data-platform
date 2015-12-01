using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [DataContract]
    public sealed class RequestFieldIdentifier
    {
        public RequestFieldIdentifier(string payload)
        {
            Payload = payload;
        }

        [DataMember]
        public string Payload { get; private set; }
    }
}