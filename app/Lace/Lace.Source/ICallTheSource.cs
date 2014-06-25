using Lace.Events;
using Lace.Response;

namespace Lace.Source
{
    public interface ICallTheSource
    {
       
        void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent);
        void TransformWebResponse(ILaceResponse response);
    }
}
