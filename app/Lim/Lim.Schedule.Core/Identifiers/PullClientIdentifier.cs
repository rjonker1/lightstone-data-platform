using System.Runtime.Serialization;
using Lim.Enums;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class PullClientIdentifier
    {
        [DataMember]
        public string Action { get; private set; }

        [DataMember]
        public short Id { get; private set; }

        public PullClientIdentifier(string action, short id)
        {
            Action = action;
            Id = id;
        }
    }
}