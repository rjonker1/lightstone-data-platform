using Lace.Events;
using Lace.Response;
using Lace.Source;

namespace Lace.Consumer
{
    public class ConsumeService : IConsumeService
    {
        private readonly ICallTheExternalSource _externalWebServiceCall;
        private readonly IHandleSourceCall _handleServiceCall;

        public ConsumeService(IHandleSourceCall handleServiceCall,
            ICallTheExternalSource externalWebServiceCall)
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
