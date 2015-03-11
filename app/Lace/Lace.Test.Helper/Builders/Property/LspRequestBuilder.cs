using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.DriversLicenseRequests;
using Lace.Test.Helper.Mothers.Requests.PropertyRequests;

namespace Lace.Test.Helper.Builders.Property
{
    public class LspRequestBuilder
    {
      
        private ILaceRequest _request;
        public ILaceRequest ForReturnProperties()
        {
            _request = new PropertiesRequest();
            return _request;
        }
    }
}
