using Lace.Events;

namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockRequestDataFromRgtVinHolderService : IRequestDataFromSource
    {
        public void FetchDataFromService(Response.ILaceResponse response, ICallTheExternalSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
