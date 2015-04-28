using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmIvidStandardRequest : IAmDataProviderRequest
    {
        IAmRequesterNameRequestField RequesterName { get; }
        IAmRequesterPhoneRequestField RequesterPhone { get; }
        IAmRequesterEmailRequestField RequesterEmail { get; }
        IAmRequestReferenceRequestField RequestReference { get; }
        IAmApplicantNameRequestField ApplicantName { get; }
        IAmReasonForApplicationRequestField ReasonForApplication { get; }
        IAmLabelRequestField Label { get; }
        IAmEngineNumberRequestField EngineNumber { get; }
        IAmChassisNumberRequestField ChassisNumber { get; }
        IAmVinNumberRequestField VinNumber { get; }
        IAmLicenceNumberRequestField LicenceNumber { get; }
        IAmRegisterNumberRequestField RegisterNumber { get; }
        IAmMakeRequestField Make { get; }
    }
}