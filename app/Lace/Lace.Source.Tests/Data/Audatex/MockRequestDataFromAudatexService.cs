using Lace.Events;
using Lace.Response;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockRequestDataFromAudatexService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheExternalWebService externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
