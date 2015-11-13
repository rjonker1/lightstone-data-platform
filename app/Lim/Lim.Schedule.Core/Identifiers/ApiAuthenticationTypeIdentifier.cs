using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiAuthenticationTypeIdentifier
    {
        public ApiAuthenticationTypeIdentifier(int id, string type)
        {
            Type = type;
            Id = id;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Type { get; private set; }
    }
}
