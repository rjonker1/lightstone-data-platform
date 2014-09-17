using Lace.Events;
using Lace.Models.Responses;
using Lace.Source;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromAudatexService : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalSource(response,laceEvent);
        }
    }
}
