using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Core
{
    [DataContract]
    public enum DataProvider
    {
        [EnumMember] Audatex,
        [EnumMember] Ivid,
        [EnumMember] IvidTitleHolder,
        [EnumMember] RgtVin,
        [EnumMember] Rgt,
        [EnumMember] Lightstone,
        [EnumMember] EntryPoint,
        [EnumMember] Initialization,
        [EnumMember] Anpr,
        [EnumMember] Jis
    }
}
