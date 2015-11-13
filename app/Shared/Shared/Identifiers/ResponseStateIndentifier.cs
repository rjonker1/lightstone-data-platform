using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
    public class ResponseStateIndentifier
    {
        public ResponseStateIndentifier()
        {
        }

        public ResponseStateIndentifier(int id, string name)
        {
            Id = id;
            Name = name;
        }


        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Name { get; private set; }
    }
}
