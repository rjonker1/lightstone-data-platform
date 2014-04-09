using Lace.Models.IvidTitleHolder;
using Lace.Models.IvidTitleHolder.Dto;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    class RequestDatafromIvidTitleHolderService : IRequestDataFromService
    {
        private ILaceRequest _request;
        public void FetchDataFromService(ILaceRequest request, ILaceResponse response)
        {
            _request = request;
            response.IvidTitleHolderResponse = new IvidTitleHolderResponse();
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
    }
}
