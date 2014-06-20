using Lace.Consumer;
using Lace.Events;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.Enums;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeIvidTitleHolderConsumer
    {
        private readonly IHandleSourceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheSource _externalWebServiceCall;

        public FakeIvidTitleHolderConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new FakeHandleIvidTitleHolderServiceCall();
            _externalWebServiceCall = new FakeCallingIvidTitleHolderExternalWebService();
        }

        public void CallIvidTitleHolderService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.IvidTitleHolder,_request);

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
