using Lace.Request;
using Lace.Response;

namespace Lace.Source
{
    public interface ICallTheExternalWebService
    {
        //void CallTheExternalWebService(ILaceRequest request, ILaceResponse response);
        void CallTheExternalWebService(ILaceResponse response);
        void TransformWebResponse(ILaceResponse response);
    }
}
