using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderResponseState
    {
        [EnumMember(Value = "Succesful Response")] Successful = 1,
        [EnumMember(Value = "Partial Response")] Partial = 2,
       // [EnumMember(Value = "Failed Response")] Failed = 3,
        [EnumMember(Value = "Critical Failure Response")] CriticalFailure = 4,
        [EnumMember(Value = "Request Abandoned")] Abandoned = 5,
        [EnumMember(Value = "No Records Found")] NoRecords = 6,
        [EnumMember(Value = "Vin Short Request")] VinShort = 7,
        [EnumMember(Value = "Technical Error Occurred")] TechnicalError = 8,
        [EnumMember(Value = "Not Handled")] NotHandled = 6
    }
}
