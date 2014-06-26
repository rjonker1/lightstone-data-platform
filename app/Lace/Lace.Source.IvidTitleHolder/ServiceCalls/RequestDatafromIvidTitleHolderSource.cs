using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class RequestDatafromIvidTitleHolderSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response,
            ICallTheSource externalSource, ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
