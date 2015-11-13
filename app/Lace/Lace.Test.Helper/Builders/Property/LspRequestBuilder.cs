using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.PropertyRequests;

namespace Lace.Test.Helper.Builders.Property
{
    public class LspRequestBuilder
    {

        private ICollection<IPointToLaceRequest> _request;
        public ICollection<IPointToLaceRequest> ForReturnProperties()
        {
            _request = new[] {new PropertiesRequest()};
            return _request;
        }
    }
}
