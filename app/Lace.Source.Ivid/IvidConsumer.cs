using System;
using System.Linq;
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
            _handleServiceCall = new HandleIvidServiceCall();
        }

        //public IvidConsumer(IHandleServiceCall handleServiceCall)
        //{
        //    _handleServiceCall = handleServiceCall;
        //}

        public ILaceResponse CallIvidService()
        {
           return _handleServiceCall.Call(c =>
                c.FetchDataFromService(_request)
                );
        }
    }
}
