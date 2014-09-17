using Lace.Events;
using Lace.Models.Responses;

namespace Lace.Source
{
    public interface ICallTheSource
    {
        void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent);
        void TransformResponse(ILaceResponse response);
    }
}
