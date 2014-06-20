using Lace.Events;
using Lace.Response;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidSource : IRequestDataFromSource
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
