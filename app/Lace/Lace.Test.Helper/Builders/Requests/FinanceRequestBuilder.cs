using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.FinanceRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class FinanceRequestBuilder
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForBmwFinanceWithVinNumber()
        {
            _request = new[] { new BmwFinanceRequestWithVinNumber() };
            return _request;
        }
    }
}
