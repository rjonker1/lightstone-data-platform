using Lace.Events;
using Lace.Models;

namespace Lace.Source.Anpr.SourceCalls
{
    public class RequestDataFromAnprSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalSource,
            ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
