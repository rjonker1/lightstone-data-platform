using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.BusinessRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class DirectorRequestBuilder
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForLightstoneDirector()
        {
            _request = new[] {new DirectorRequest()};
            return _request;
        }
    }
}