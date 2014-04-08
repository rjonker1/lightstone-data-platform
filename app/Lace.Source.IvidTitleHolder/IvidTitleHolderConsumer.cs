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


        public ILaceResponse CallIvidTitleHolderService()
        {
            if (!_handleServiceCall.CanHandle(_request)) return NotHandledReponse();

            return
                _handleServiceCall
                    .Call(c =>
                        c.FetchDataFromService(_request)
                    );


            // return Helpers.ConvertFunctions.ConvertObject<IvidTitleHolderServiceResponse>(response);
        }

        private static ILaceResponse NotHandledReponse()
        {
            //var response = new IvidTitleHolderServiceResponse();
            //response.NotHandled();
            //return response;
            return null;
        }
    }

}
