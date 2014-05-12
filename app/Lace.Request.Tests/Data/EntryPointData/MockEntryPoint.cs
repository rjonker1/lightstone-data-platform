using System.Collections.Generic;
using Lace.Request.Entry;
using Lace.Request.Entry.Checks;
using Lace.Response.ExternalServices;

namespace Lace.Request.Tests.Data.EntryPointData
{
    public class MockEntryPoint : IEntryPoint
    {

        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly IGetRequiredRequestedTypes _getRequestedType;

        public MockEntryPoint()
        {
            _getRequestedType = new MockGetRequestedTypeToLoad();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }
        

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            GetRequestedTypeToLoad(request);

            return !_checkForDuplicateRequests.IsRequestDuplicated(request)
                ? new Initialize(request, _getRequestedType.RequestedTypeToLoad).LaceResponses
                : null;
        }

        private void GetRequestedTypeToLoad(ILaceRequest request)
        {
            _getRequestedType.GetRequestedType(request);
        }
    }
}
