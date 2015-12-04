using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.XdsRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class XdsRequestBuilder
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForIdVerificaitonWithIdNumber()
        {
            _request = new[] { new XdsIdVerificationRequests() };
            return _request;
        }
    }
}
