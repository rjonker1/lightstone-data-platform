using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Scans;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.DriversLicenseRequests
{
    public class DriversLicenseDecryptionRequest : IAmDriversLicenseRequest
    {
        public IHaveDriversLicenseInformation DriversLicense
        {
            get { return new RequestDriversLicenseInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IAmPackageForRequest Package
        {
            get { return DriversLicenseSourcePackage.DriversLicenseDecryptionPackage(); }
        }

        public IHaveAggregation Aggregation
        {
            get { return new AggregationInformation();}
        }
    }
}
