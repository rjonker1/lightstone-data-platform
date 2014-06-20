using Lace.Events;
using Lace.Response;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class RequestDataFromRgtVinSource : IRequestDataFromSource
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
           externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
