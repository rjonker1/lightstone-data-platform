using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class SignioDriversLicenseRequest : IAmSignioDriversLicenseDecryptionRequest
    {
        public SignioDriversLicenseRequest(IAmScanDataRequestField scanData, IAmRegistrationCodeRequestField registrationCode,
            IAmUserNameRequestField userName, IAmUserIdRequestField userId)
        {
            ScanData = scanData;
            RegistrationCode = registrationCode;
            Username = userName;
            UserId = userId;
        }

        public IAmScanDataRequestField ScanData { get; private set; }
        public IAmRegistrationCodeRequestField RegistrationCode { get; private set; }
        public IAmUserNameRequestField Username { get; private set; }
        public IAmUserIdRequestField UserId { get; private set; }
    }
}
