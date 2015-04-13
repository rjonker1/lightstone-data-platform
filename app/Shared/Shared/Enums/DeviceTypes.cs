using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DeviceTypes
    {
        [EnumMember] Desktop,
        [EnumMember] Phone,
        [EnumMember] Tablet,
        [EnumMember] ApiClient
    }
}
