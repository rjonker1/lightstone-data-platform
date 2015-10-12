using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderResponseState
    {
        [EnumMember] Successful = 1,
        [EnumMember] Partial = 2,
        [EnumMember] Failed = 3,
        [EnumMember] CriticalFailure = 4,
        [EnumMember] Abandoned = 5,
        [EnumMember] NoRecords = 6,
        [EnumMember] VinShort = 7,
        [EnumMember] TechnicalError = 8
    }
}
