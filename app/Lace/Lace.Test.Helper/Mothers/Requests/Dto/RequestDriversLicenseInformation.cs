using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Builders.Scans;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestDriversLicenseInformation : IHaveDriversLicenseInformation
    {
        public RequestDriversLicenseInformation()
        {
            
        }

        //public RequestDriversLicenseInformation(string registrationCode, string scanData, string userId, string userName)
        //{
        //    RegistrationCode = registrationCode;
        //    ScanData = scanData;
        //    UserId = userId;
        //    Username = userName;
        //}

        public string RegistrationCode
        {
            get { return string.Empty; }
        }

        public string ScanData
        {
            get { return DriversLicenseScan.GetBase64String(); }
        }

        public Guid UserId
        {
            get { return new Guid("5A3DA2CD-6036-440C-B591-58C70B6F2EF2"); }
        }

        public string Username
        {
            get
            {
                return "jonathan@dnacars.co.za";
            }
        }

    }
}
