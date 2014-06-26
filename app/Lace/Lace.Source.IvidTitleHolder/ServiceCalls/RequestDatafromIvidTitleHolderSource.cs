using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class RequestDatafromIvidTitleHolderSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response,
            ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
