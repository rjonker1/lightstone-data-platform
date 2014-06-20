using Lace.Events;
using Lace.Source;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromRgtVinHolderSource : IRequestDataFromSource
    {
        public void FetchDataFromService(Response.ILaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalWebService(response, laceEvent);
        }
    }
}
