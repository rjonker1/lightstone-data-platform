using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
    public class StateIdentifier
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Name { get; private set; }

        public StateIdentifier()
        {
        }

        public StateIdentifier(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
