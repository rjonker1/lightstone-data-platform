using Lace.Request;
using Lace.Response;
using Lace.Source.RgtVin.ServiceCalls;

namespace Lace.Source.RgtVin
{
    public class RgtVinConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public RgtVinConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleRgtVinServiceCall();
            _externalWebServiceCall = new CallRgtVinExternalWebService(request);
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
