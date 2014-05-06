using Lace.Response;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class RequestDataFromAudatexService : IRequestDataFromService
    {
        public void FetchDataFromService(ILaceResponse response,
            ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(response);
        }
    }
}
