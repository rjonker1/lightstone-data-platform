using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum SystemType
    {
        [EnumMember] Api,
        [EnumMember] Limm,
        [EnumMember] Web
    }
}
