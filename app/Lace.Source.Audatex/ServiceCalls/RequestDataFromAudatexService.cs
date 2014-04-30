using Lace.Request;
using Lace.Response;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class RequestDataFromAudatexService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceRequest request, ILaceResponse response,
            ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(request, response);
        }
    }
}
