using Lace.Events;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockRequestDataFromIvidTitleHolderService : IRequestDataFromSource
    {
        public void FetchDataFromService(Response.ILaceResponse response, ICallTheExternalSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response,laceEvent);
        }
    }
}
