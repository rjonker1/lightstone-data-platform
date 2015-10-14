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
        Error,
        [EnumMember]
        Performance,
        [EnumMember]
        Security,
        [EnumMember]
        Fault,
    }

    [DataContract]
    public enum CommandType
    {
        [EnumMember]
        Accounting,
        [EnumMember]
        Configuration,
        [EnumMember]
        Error,
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
        [EnumMember]
        Fault
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
