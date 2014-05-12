using Lace.Request;
using Lace.Response;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockAudatexConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public MockAudatexConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new MockHandleAudatexServiceCall();
            _externalWebServiceCall = new MockCallingAudatexExternalWebService(_request);
        }

        public void CallAudatexService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request, response)) return;

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall));
        }
    }

}
