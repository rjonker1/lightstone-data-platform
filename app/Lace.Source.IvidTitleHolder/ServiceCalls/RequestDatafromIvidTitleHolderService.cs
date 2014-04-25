using Lace.Request;
using Lace.Response;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class RequestDatafromIvidTitleHolderService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceRequest request, ILaceResponse response,
            ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(request, response);
        }
    }
}
