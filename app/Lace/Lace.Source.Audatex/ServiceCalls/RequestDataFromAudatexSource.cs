using Lace.Events;
using Lace.Models;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class RequestDataFromAudatexSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response,
            ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalSource(response, laceEvent);
        }
    }
}
