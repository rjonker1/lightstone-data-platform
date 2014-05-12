using Lace.Request;
using Lace.Response;

namespace Lace.Source.Tests.Data.Ivid
{
    public class MockIvidConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public MockIvidConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new MockHandleIvidServiceCall();
            _externalWebServiceCall = new MockCallingIvidExternalWebService();
        }

        public void CallIvidService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request, response)) return;

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall));
        }
    }

}
