using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmSignioDriversLicenseDecryptionRequest : IAmDataProviderRequest
    {
        IAmScanDataRequestField ScanData { get; }
        IAmRegistrationCodeRequestField RegistrationCode { get; }
        IAmUserNameRequestField Username { get; }
        IAmUserIdRequestField UserId { get; }
    }
}