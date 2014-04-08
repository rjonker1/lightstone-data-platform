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
            if (!_handleServiceCall.CanHandle(_request)) return new IvidTitleHolderServiceResponse() {Handled = false};

            return
                _handleServiceCall
                    .Call(c =>
                        c.FetchDataFromService(_request)
                    );
        }
    }

}
