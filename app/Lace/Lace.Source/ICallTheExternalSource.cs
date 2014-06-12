using Lace.Events;
using Lace.Response;

namespace Lace.Source
{
    public interface ICallTheExternalSource
    {
        //void CallTheExternalWebService(ILaceRequest request, ILaceResponse response);
        void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent);
        void TransformWebResponse(ILaceResponse response);
    }
}
