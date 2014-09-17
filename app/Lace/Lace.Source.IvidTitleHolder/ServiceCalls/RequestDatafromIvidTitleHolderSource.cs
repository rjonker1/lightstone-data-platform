using Lace.Events;
using Lace.Models.Responses;

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
