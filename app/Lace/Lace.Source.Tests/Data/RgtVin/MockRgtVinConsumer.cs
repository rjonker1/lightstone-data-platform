using Lace.Consumer;
using Lace.Events;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;

namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockRgtVinConsumer
    {
        private readonly IHandleSourceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheSource _externalWebServiceCall;

        public MockRgtVinConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new MockHandleRgtVinServiceCall();
            _externalWebServiceCall = new MockCallingRgtVinExternalWebService();
        }

        public void CallRgtVinService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.RgtVin,_request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
                return;
            }

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall, laceEvent)
                );
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new IvidTitleHolderResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
