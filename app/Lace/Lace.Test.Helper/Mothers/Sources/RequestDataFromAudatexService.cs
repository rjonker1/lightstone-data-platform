using Lace.Events;
using Lace.Response;
using Lace.Source;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromAudatexService : IRequestDataFromSource
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheExternalSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
