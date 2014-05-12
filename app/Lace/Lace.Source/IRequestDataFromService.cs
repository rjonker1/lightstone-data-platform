using Lace.Response;

namespace Lace.Source
{
    public interface IRequestDataFromService
    {
        //void FetchDataFromService(ILaceRequest request, ILaceResponse response, ICallTheExternalWebService externalWebService);
        void FetchDataFromService(ILaceResponse response, ICallTheExternalWebService externalWebService);
    }
}
