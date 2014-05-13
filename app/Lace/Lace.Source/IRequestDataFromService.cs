using Lace.Response;

namespace Lace.Source
{
    public interface IRequestDataFromService
    {
        void FetchDataFromService(ILaceResponse response, ICallTheExternalWebService externalWebService);
    }
}
