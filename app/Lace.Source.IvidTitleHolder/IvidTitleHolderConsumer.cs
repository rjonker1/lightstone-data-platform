using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.ServiceCalls;

namespace Lace.Source.IvidTitleHolder
{
    public class IvidTitleHolderConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;


        public IvidTitleHolderConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleIvidTitleHolderServiceCall();
            _externalWebServiceCall = new CallIvidTitleHolderExternalWebService();
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
