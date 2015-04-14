using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Scans;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.DriversLicenseRequests
{
    public class DriversLicenseDecryptionRequest : IAmDriversLicenseRequest
    {
        public IHaveDriversLicense DriversLicense
        {
            get { return new RequestDriversLicenseInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get { return DriversLicenseSourcePackage.DriversLicenseDecryptionPackage(); }
        }

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation();}
        }


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation();}
        }
    }
}
