using Lace.Events;
using Lace.Response;

namespace Lace.Source
{
    public interface ICallTheSource
    {
        void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent);
        void TransformResponse(ILaceResponse response);
    }
}
