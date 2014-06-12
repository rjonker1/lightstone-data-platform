using Lace.Events;
using Lace.Response;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockRequestDataFromAudatexService : IRequestDataFromSource
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheExternalSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
