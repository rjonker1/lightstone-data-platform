using Lace.Request;
using Lace.Response;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidService : IRequestDataFromService
    {
        //private ILaceRequest _request;

        public void FetchDataFromService(ILaceRequest request, ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            //_request = request;
            externalWebService.CallTheExternalWebService(request,response);
        }
    }
}
