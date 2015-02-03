using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestDriversLicenseInformation : IProvideDriversLicenseInformationForRequest
    {
        public RequestDriversLicenseInformation()
        {
            
        }

        public RequestDriversLicenseInformation(string registrationCode, string scanData, string userId, string userName)
        {
            RegistrationCode = registrationCode;
            ScanData = scanData;
            UserId = userId;
            Username = userName;
        }

        public string RegistrationCode { get; private set; }

        public string ScanData { get; private set; }

        public string UserId { get; private set; }

        public string Username { get; private set; }
    }
}
