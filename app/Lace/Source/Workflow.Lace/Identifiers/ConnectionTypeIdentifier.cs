using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class ConnectionTypeIdentifier
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Connection { get; set; }

        public ConnectionTypeIdentifier(string type, string source)
        {
            Type = type;
            Connection = source;
        }

        public ConnectionTypeIdentifier()
        {
            
        }
    }
}
