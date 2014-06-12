using Lace.Consumer;
using Lace.Events;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.Enums;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeAudatexConsumer
    {
        private readonly IHandleSourceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheExternalSource _externalWebServiceCall;

        public FakeAudatexConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new FakeHandleAudatexServiceCall();
            _externalWebServiceCall = new FakeCallingAudatexExternalWebService(request);
        }

        public void CallAudatexService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Audatex,_request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
                return;
            }

            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromService(response, _externalWebServiceCall, laceEvent));
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasNotBeenHandled();
        }
    }
}
