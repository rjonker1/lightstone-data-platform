using Lace.Events;
using Lace.Models.Responses;

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
