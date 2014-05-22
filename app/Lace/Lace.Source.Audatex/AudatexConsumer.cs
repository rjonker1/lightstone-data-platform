using Lace.Consumer;
using Lace.Events;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.ServiceCalls;
using Lace.Source.Enums;

namespace Lace.Source.Audatex
{
    public class AudatexConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public AudatexConsumer(ILaceRequest request)
        {
        _handleServiceCall = new HandleAudatexServiceCall();
            _externalWebServiceCall = new CallAudatexExternalWebService(request);
        }

        public void CallAudatexService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Audatex);

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
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasNotBeenHandled();
        }
    }
}
