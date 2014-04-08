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

        public ILaceResponse CallRgtVinService()
        {
            if (!_handleServiceCall.CanHandle(_request)) return NotHandledResponse();

            return
                _handleServiceCall
                    .Call(c =>
                        c.FetchDataFromService(_request)
                    );

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
