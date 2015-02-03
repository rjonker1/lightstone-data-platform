using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.DriversLicenseRequests;

namespace Lace.Test.Helper.Builders.Scans
{
    public class DriversLicenseRequestBuilder
    {
        private ILaceRequest _request;
        public ILaceRequest ForDriversLicenseScan()
        {
            _request = new DriversLicenseDecryptionRequest();
            return _request;
        }
    }
}
