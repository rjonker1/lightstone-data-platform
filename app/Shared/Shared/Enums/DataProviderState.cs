using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    public enum DataProviderState
    {
        [EnumMember] Successful = 1,
        [EnumMember] PartialFailure = 2,
        [EnumMember] Failed = 3
    }
}
