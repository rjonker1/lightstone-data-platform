using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class ActionIdentifier
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Name { get; private set; }

        public ActionIdentifier(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
