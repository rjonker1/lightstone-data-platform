using Lace.Events;
using Lace.Models.Responses;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
           externalWebService.CallTheExternalSource(response, laceEvent);
        }
    }
}
