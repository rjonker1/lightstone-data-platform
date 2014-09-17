using Lace.Events;
using Lace.Models;

namespace Lace.Source
{
    public interface ICallTheSource
    {
        void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent);
        void TransformResponse(IProvideLaceResponse response);
    }
}
