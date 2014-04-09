using Lace.Request;
using Lace.Response;
using System;
using Lace.Source.RgtVin.ServiceCalls;

namespace Lace.Source.RgtVin
{
    public class RgtVinConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;

        public RgtVinConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleRgtVinServiceCall();
        }

        public bool CallRgtVinService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request)) return false;

            _handleServiceCall
                    .Call(c =>
                        c.FetchDataFromService(_request,response)
                    );

            return true;
            // return Helpers.ConvertFunctions.ConvertObject<RgtVinServiceResponse>(response);
        }

        private static ILaceResponse NotHandledResponse()
        {
            //var response = new RgtVinServiceResponse();
            //response.NotHandled();
            //return response;
            return null;
        }
    }
}
