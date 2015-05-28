using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ClientIdentifier
    {
        public ClientIdentifier(long clientId)
        {
            ClientId = clientId;
        }

        [DataMember]
        public long ClientId { get; private set; }
    }
}
