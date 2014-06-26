using Lace.Events;

namespace Lace.Source.Tests.Data.Ivid
{
    public class MockRequestDataFromIvidService : IRequestDataFromSource
    {
        public void FetchDataFromSource(Response.ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
