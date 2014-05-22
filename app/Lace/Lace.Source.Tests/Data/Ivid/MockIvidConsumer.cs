using Lace.Consumer;
using Lace.Events;
using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;

namespace Lace.Source.Tests.Data.Ivid
{
    public class MockIvidConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public MockIvidConsumer(ILaceRequest request)
        {
            _handleServiceCall = new MockHandleIvidServiceCall();
            _externalWebServiceCall = new MockCallingIvidExternalWebService();
        }

        public void CallIvidService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Ivid);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
                return;
            }

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall, laceEvent));
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasNotBeenHandled();
        }

    }
}
