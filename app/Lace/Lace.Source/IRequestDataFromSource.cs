using Lace.Events;
using Lace.Models;

namespace Lace.Source
{
    public interface IRequestDataFromSource
    {
        void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalSource, ILaceEvent laceEvent);
    }
}
