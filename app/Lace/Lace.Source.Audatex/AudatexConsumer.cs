using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.ServiceCalls;

namespace Lace.Source.Audatex
{
    public class AudatexConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public AudatexConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleAudatexServiceCall();
            _externalWebServiceCall = new CallAudatexExternalWebService(request);
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
