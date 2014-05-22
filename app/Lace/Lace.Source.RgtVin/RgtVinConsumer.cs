using Lace.Consumer;
using Lace.Events;
using Lace.Models.RgtVin;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;
using Lace.Source.RgtVin.ServiceCalls;

namespace Lace.Source.RgtVin
{
    public class RgtVinConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public RgtVinConsumer(ILaceRequest request)
        {
            _handleServiceCall = new HandleRgtVinServiceCall();
            _externalWebServiceCall = new CallRgtVinExternalWebService(request);
        }

        public void CallRgtVinService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.RgtVin);

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
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
