﻿using Lace.Consumer;
using Lace.Events;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockIvidTitleHolderConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public MockIvidTitleHolderConsumer(ILaceRequest request)
        {
            _handleServiceCall = new MockHandleIvidTitleHolderServiceCall();
            _externalWebServiceCall = new MockCallingIvidTitleHolderExternalWebService();
        }

        public void CallIvidTitleHolderService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.IvidTitleHolder);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
                return;
            }

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall, laceEvent)
                );
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasNotBeenHandled();
        }
    }
}
