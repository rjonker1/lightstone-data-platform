using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Core
{
    [DataContract]
    public enum Category
    {
        [EnumMember] Accounting,
        [EnumMember] Configuration,
        [EnumMember] Fault,
        [EnumMember] Performance,
        [EnumMember] Security
    }

    [DataContract]
    public enum CommandType
    {
        [EnumMember] Accounting,
        [EnumMember] Configuration,
        [EnumMember] Fault,
        [EnumMember] Performance,
        [EnumMember] Security,
        [EnumMember] Begin,
        [EnumMember] End
    }
}
