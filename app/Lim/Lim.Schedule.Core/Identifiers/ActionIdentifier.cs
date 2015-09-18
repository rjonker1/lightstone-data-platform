using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ActionIdentifier
    {
        [DataMember]
        public string Action { get; private set; }

        [DataMember]
        public short Id { get; private set; }

        public ActionIdentifier(string action, short id)
        {
            Action = action;
            Id = id;
        }
    }
}
