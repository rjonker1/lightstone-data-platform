using Lace.Request;
using Lace.Response;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockIvidTitleHolderConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public MockIvidTitleHolderConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new MockHandleIvidTitleHolderServiceCall();
            _externalWebServiceCall = new MockCallingIvidTitleHolderExternalWebService();
        }

        public void CallIvidTitleHolderService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request, response)) return;

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(_request, response, _externalWebServiceCall)
                );
        }
    }
}
