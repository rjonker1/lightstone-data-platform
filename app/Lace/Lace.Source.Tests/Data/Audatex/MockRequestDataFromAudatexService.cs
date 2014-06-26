using Lace.Events;
using Lace.Response;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockRequestDataFromAudatexService : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
