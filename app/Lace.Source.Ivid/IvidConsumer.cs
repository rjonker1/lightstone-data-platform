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


        public ILaceResponse CallIvidService()
        {
            if (!_handleServiceCall.CanHandle(_request)) return NotHandledResponse();

            return 
                _handleServiceCall
                    .Call(c =>
                        c.FetchDataFromService(_request));

           // return Helpers.ConvertFunctions.ConvertObject<IvidResponse>(response);
        }

        private static ILaceResponse NotHandledResponse()
        {
            //var response = new IvidResponse();
            //response.NotHandled();
            //return response;
            return null;
        }
    }
}
