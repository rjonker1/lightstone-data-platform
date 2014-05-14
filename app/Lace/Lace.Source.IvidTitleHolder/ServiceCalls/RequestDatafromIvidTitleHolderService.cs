using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class RequestDatafromIvidTitleHolderService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceResponse response,
            ICallTheExternalWebService externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
