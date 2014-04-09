using System;
using System.Linq;
using Lace.Models.IvidTitleHolder;
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


        public void CallIvidTitleHolderService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request, response)) return;

            _handleServiceCall
                .Call(c =>
                    c.FetchDataFromService(_request, response)
                );
            // return Helpers.ConvertFunctions.ConvertObject<IvidTitleHolderServiceResponse>(response);
        }
    }
}
