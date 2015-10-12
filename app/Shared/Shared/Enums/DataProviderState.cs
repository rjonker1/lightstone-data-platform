using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderState
    {
        [EnumMember] Successful = 1,
        [EnumMember] Partial = 2,
        [EnumMember] Failed = 3,
        [EnumMember] CriticalFailure = 4,
        [EnumMember] Abandoned = 5,
        [EnumMember] NoRecordsNonBillable = 6,
        [EnumMember] NoRecordsBillable = 7,
        [EnumMember] VinShort = 8,
        [EnumMember] TechnicalError = 9,
    }
}
