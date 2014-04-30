using Lace.Request;
using Lace.Response;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class RequestDataFromRgtVinService : IRequestDataFromService
    {
        //private ILaceRequest _request;

        public void FetchDataFromService(ILaceRequest request, ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
           externalWebService.CallTheExternalWebService(request, response);
        }
    }
}
