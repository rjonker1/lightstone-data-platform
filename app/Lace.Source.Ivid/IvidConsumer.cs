using System;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.ServiceCalls;

namespace Lace.Source.Ivid
{
    public class IvidConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;

        public IvidConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleIvidServiceCall(request);
        }


        public bool CallIvidService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request))
            {
                NotHandledResponse(response);
                return true;
            }
            
            _handleServiceCall
                    .Call(c =>
                        c.FetchDataFromService(_request,response));

            return true;

            // return Helpers.ConvertFunctions.ConvertObject<IvidResponse>(response);
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new ResponseHandled();
            response.IvidResponseHandled.HasNotBeenHandled();
        }
    }
}
