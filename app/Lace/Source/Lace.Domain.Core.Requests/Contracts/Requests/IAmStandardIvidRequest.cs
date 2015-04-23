using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmStandardIvidRequest : IAmDataProviderRequest
    {
        IAmRequesterNameRequestField RequesterName { get; }
        IAmRequesterPhoneRequestField RequesterPhone { get; }
        IAmRequesterEmailRequestField RequesterEmail { get; }
        IAmRequestReferenceRequestField RequestReference { get; }
        IAmApplicantNameRequestField ApplicantName { get; }
        IAmReasonForApplicationRequestField ReasonForApplication { get; }
        IAmLabelRequestField Label { get; }
        IAmEngineNumberRequestField EngineNumber { get; }
        IAmRegisterNumberRequestField RegisterNumber { get; }
        IAmLicenseNumberRequestField LicenseNumber { get; }
        IAmMakeRequestField Make { get; }
    }
}