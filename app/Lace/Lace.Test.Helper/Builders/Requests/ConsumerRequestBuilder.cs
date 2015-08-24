using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.ConsumerRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class ConsumerRequestBuilder 
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForSpecifications()
        {
            _request = new[] { new SpecificationsRequest() };
            return _request;
        }
    }
}
