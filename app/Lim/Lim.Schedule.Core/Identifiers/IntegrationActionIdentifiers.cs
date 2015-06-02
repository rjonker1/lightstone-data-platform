using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class IntegrationActionIdentifier
    {
        [DataMember]
        public string Action { get; private set; }

        [DataMember]
        public short Id { get; private set; }

        public IntegrationActionIdentifier(string action, short id)
        {
            Action = action;
            Id = id;
        }
    }
}
