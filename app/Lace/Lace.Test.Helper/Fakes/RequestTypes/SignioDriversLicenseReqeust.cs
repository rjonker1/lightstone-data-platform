using System;
using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class SignioDriversLicenseRequest : IAmSignioDriversLicenseDecryptionRequest
    {
        private SignioDriversLicenseRequest(string scanData, string registrationCode, Guid userId, string userName)
        {
            RegistrationCode = RegistrationCodeRequestField.Get(registrationCode);
            ScanData = ScanDataRequestField.Get(scanData);
            UserId = UserIdRequestField.Get(Convert.ToString(userId));
            Username = UsernameRequestField.Get(userName);
        }

        public static IAmSignioDriversLicenseDecryptionRequest Request(string scanData, string registrationCode, Guid userId, string userName)
        {
            return new SignioDriversLicenseRequest(scanData,registrationCode,userId,userName);
        }

        public IAmRegistrationCodeRequestField RegistrationCode { get; private set; }

        public IAmScanDataRequestField ScanData { get; private set; }

        public IAmUserIdRequestField UserId { get; private set; }

        public IAmUserNameRequestField Username { get; private set; }
    }
}
