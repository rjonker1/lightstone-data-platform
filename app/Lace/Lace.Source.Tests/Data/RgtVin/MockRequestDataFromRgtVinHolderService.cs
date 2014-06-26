using Lace.Events;

namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockRequestDataFromRgtVinHolderService : IRequestDataFromSource
    {
        public void FetchDataFromSource(Response.ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
