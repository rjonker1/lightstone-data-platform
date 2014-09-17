using Lace.Events;
using Lace.Models.Responses;

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
