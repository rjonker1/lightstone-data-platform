using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.BusinessRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class CompanyRequestBuilder
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForLightstoneCompany()
        {
            _request = new[] {new CompaniesRequest()};
            return _request;
        }
    }
}
