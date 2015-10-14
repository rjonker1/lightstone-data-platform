using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class NoRecordBillableIdentifier
    {
        public NoRecordBillableIdentifier()
        {
            
        }

        public NoRecordBillableIdentifier(int id, string name)
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
