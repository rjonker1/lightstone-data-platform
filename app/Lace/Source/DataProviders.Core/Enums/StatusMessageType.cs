using System.Runtime.Serialization;

namespace Lace.Domain.DataProviders.Core.Enums
{

    [DataContract]
    public enum StatusMessageType
    {
        [EnumMember(Value = "")]
        NoStatusFeedbackRequired,
        [EnumMember(Value = "The licence plate number for this vehicle has changed. Please check the vehicle carefully.")]
        LicensePlateMismatch,
        [EnumMember(Value = "Vehicle requires further investigation.  Please contact IVID on (033) 234 4083 or ivid@telkomsa.net")]
        FurtherInvestigation
    }
}
