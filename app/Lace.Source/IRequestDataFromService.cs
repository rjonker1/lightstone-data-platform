using Lace.Request;
using Lace.Response;

namespace Lace.Source
{
    public interface IRequestDataFromService
    {
        ILaceResponse FetchDataFromService(ILaceRequest request);
    }
}
