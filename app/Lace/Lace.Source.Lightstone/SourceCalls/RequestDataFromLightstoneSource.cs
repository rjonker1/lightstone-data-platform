using Lace.Events;
using Lace.Response;

namespace Lace.Source.Lightstone.SourceCalls
{
    public class RequestDataFromLightstoneSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(ILaceResponse response, ICallTheSource externalSource, ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
