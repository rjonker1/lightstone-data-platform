using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Source;

namespace Lace.Consumer
{
    public class ConsumeService : IConsumeService
    {
        private readonly ICallTheExternalWebService _externalWebServiceCall;
        private readonly IHandleServiceCall _handleServiceCall;
        //private readonly ILaceRequest _request;

        public ConsumeService(ILaceRequest request,
            IHandleServiceCall handleServiceCall,
            ICallTheExternalWebService externalWebServiceCall)
        {
            _handleServiceCall = handleServiceCall;
            _externalWebServiceCall = externalWebServiceCall;
        }

        public void CallService(ILaceResponse response, ILaceEvent laceEvent)
        {
            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall, laceEvent));
        }
    }
}
