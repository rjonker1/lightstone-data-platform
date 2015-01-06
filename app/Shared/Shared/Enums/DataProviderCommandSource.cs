using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderCommandSource
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
