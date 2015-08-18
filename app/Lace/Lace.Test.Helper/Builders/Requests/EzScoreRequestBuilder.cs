using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.EzScoreRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class PCubedRequestBuilder
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForEzScore()
        {
            _request = new[] { new EzScoreRequest() };
            return _request;
        }
    }
}
