using Lace.Models.RgtVin;
using Lace.Models.RgtVin.Dto;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.RgtVin.ServiceCalls
{
    class RequestDataFromRgtVinService : IRequestDataFromService
    {
        private ILaceRequest _request;

        public void FetchDataFromService(ILaceRequest request, ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            _request = request;
            response.RgtVinResponse = new RgtVinResponse();
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }
    }
}
