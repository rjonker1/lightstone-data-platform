using Lace.Request;
using Lace.Response;

namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockRgtVinConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public MockRgtVinConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new MockHandleRgtVinServiceCall();
            _externalWebServiceCall = new MockCallingRgtVinExternalWebService();
        }

        public void CallRgtVinService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request, response)) return;

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall)
                );
        }
    }
}
