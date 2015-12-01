using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [DataContract]
    public sealed class RequestFieldIdentifier
    {
        public RequestFieldIdentifier(byte[] payload)
        {
            Payload = payload;
        }

        [DataMember]
        public byte[] Payload { get; private set; }
    }
}