using Lace.Events;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockRequestDataFromIvidTitleHolderService : IRequestDataFromSource
    {
        public void FetchDataFromSource(Response.ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
