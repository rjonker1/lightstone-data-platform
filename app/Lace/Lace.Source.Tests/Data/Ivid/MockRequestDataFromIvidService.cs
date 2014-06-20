using Lace.Events;

namespace Lace.Source.Tests.Data.Ivid
{
    public class MockRequestDataFromIvidService : IRequestDataFromSource
    {
        public void FetchDataFromService(Response.ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
