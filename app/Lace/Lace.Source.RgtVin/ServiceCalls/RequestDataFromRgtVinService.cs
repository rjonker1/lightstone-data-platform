using Lace.Events;
using Lace.Response;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class RequestDataFromRgtVinService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheExternalWebService externalWebService, ILaceEvent laceEvent)
        {
           externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
