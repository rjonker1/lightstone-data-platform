using Lace.Response;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(response);
        }
    }
}
