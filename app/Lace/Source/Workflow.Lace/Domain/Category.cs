using System.Runtime.Serialization;

namespace Workflow.Lace.Domain
{
    [DataContract]
    public enum Category
    {
        [EnumMember]
        Accounting,
        [EnumMember]
        Configuration,
        [EnumMember]
        Fault,
        [EnumMember]
        Performance,
        [EnumMember]
        Security
    }

    [DataContract]
    public enum CommandType
    {
        [EnumMember]
        Accounting,
        [EnumMember]
        Configuration,
        [EnumMember]
        Fault,
        [EnumMember]
        Transformation,
        [EnumMember]
        Security,
        [EnumMember]
        BeginExecution,
        [EnumMember]
        EndExecution,
        [EnumMember]
        StartSourceCall,
        [EnumMember]
        EndSourceCall,

    }


    [DataContract]
    public enum ExecutionOrder
    {
        [EnumMember]
        First = 1,
        [EnumMember]
        Second = 2,
        [EnumMember]
        Third = 3,
        [EnumMember]
        Fourth = 4,
        [EnumMember]
        Fifth = 5,
        [EnumMember]
        Sixth = 6,
        [EnumMember]
        Seventh = 7,
        [EnumMember]
        Eighth = 8,
        [EnumMember]
        Ninth = 9,
        [EnumMember]
        Tenth = 10,
    }
}
