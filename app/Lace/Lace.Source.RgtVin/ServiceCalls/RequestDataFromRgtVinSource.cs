using Lace.Events;
using Lace.Models;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class RequestDataFromRgtVinSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
           externalWebService.CallTheExternalSource(response, laceEvent);
        }
    }
}
