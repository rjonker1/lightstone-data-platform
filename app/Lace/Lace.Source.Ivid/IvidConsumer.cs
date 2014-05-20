﻿using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.ServiceCalls;

namespace Lace.Source.Ivid
{
    public class IvidConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public IvidConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleIvidServiceCall();
            _externalWebServiceCall = new CallIvidExternalWebService(_request);
        }

        public void CallIvidService(ILaceResponse response, ILaceEvent laceEvent)
        {
            if (!_handleServiceCall.CanHandle(_request, response)) return;

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall, laceEvent));
        }

    }
}