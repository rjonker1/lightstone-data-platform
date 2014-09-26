using Lace.Events;
using Lace.Models;

namespace Lace.Source.Jis.SourceCalls
{
    public class RequestDataFromJisSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalSource,
            ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
