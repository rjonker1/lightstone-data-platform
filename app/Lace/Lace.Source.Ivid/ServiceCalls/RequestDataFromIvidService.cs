using Lace.Events;
using Lace.Response;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheExternalWebService externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
