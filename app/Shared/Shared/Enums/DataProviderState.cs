using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderState
    {
        [EnumMember] Successful = 1,
        [EnumMember] PartialFailure = 2,
        [EnumMember] Failed = 3,
        [EnumMember] CriticalFailure = 4
    }
}
