using Lace.Events;
using Lace.Response;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class RequestDataFromAudatexSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response,
            ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalSource(response, laceEvent);
        }
    }
}
