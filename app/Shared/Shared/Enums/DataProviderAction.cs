using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    public enum DataProviderAction
    {
        [EnumMember] Request = 1,
        [EnumMember] Response = 2,
    }
}
