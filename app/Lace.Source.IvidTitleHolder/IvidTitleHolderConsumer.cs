using System;
using System.Linq;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.ServiceCalls;

namespace Lace.Source.IvidTitleHolder
{
    public class IvidTitleHolderConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;


        public IvidTitleHolderConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleIvidTitleHolderServiceCall();
        }


        public bool CallIvidTitleHolderService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request))
            {
                NotHandledReponse(response);
                return true;
            }

            _handleServiceCall
                    .Call(c =>
                        c.FetchDataFromService(_request, response)
                    );

            return true;
            // return Helpers.ConvertFunctions.ConvertObject<IvidTitleHolderServiceResponse>(response);
        }

        private static void NotHandledReponse(ILaceResponse response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new ResponseHandled();
            response.IvidTitleHolderResponseHandled.HasNotBeenHandled();
        }
    }

}
