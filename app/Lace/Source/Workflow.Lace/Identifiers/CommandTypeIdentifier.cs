using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [DataContract]
    public class CommandTypeIdentifier
    {
        public CommandTypeIdentifier(short id, string name)
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
