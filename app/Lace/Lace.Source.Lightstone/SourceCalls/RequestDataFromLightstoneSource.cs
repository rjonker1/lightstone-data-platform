using Lace.Events;
using Lace.Models;
namespace Lace.Source.Lightstone.SourceCalls
{
    public class RequestDataFromLightstoneSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalSource, ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
