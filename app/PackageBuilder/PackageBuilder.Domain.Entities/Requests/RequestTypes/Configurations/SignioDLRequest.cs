using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class SignioDriversLicenseRequest : IAmSignioDriversLicenseDecryptionRequest
    {
        public SignioDriversLicenseRequest(ICollection<IAmRequestField> requestFields)
        {
            ScanData = requestFields.GetRequestField<IAmScanDataRequestField>();
            RegistrationCode = requestFields.GetRequestField<IAmRegistrationCodeRequestField>();
            Username = requestFields.GetRequestField<IAmUserNameRequestField>();
            UserId = requestFields.GetRequestField<IAmUserIdRequestField>();
        }

        public IAmScanDataRequestField ScanData { get; private set; }
        public IAmRegistrationCodeRequestField RegistrationCode { get; private set; }
        public IAmUserNameRequestField Username { get; private set; }
        public IAmUserIdRequestField UserId { get; private set; }
    }
}