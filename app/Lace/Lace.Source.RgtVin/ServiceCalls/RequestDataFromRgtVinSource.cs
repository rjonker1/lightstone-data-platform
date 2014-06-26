using Lace.Events;
using Lace.Response;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class RequestDataFromRgtVinSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
           externalWebService.CallTheExternalSource(response, laceEvent);
        }
    }
}
