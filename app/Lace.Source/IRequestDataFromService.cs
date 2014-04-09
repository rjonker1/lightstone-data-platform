using Lace.Request;
using Lace.Response;

namespace Lace.Source
{
    public interface IRequestDataFromService
    {
        void FetchDataFromService(ILaceRequest request, ILaceResponse response);
    }
}
