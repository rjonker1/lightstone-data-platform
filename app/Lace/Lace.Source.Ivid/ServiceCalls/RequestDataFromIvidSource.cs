using Lace.Events;
using Lace.Response;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
           externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
