using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.DriversLicenseRequests;

namespace Lace.Test.Helper.Builders.Scans
{
    public class DriversLicenseRequestBuilder
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForDriversLicenseScan()
        {
            _request = new[] {new DriversLicenseDecryptionRequest()};
            return _request;
        }
    }
}
