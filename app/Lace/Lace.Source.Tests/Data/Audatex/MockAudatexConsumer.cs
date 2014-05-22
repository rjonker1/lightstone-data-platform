using Lace.Consumer;
using Lace.Events;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockAudatexConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public MockAudatexConsumer(ILaceRequest request)
        {
            _handleServiceCall = new MockHandleAudatexServiceCall();
            _externalWebServiceCall = new MockCallingAudatexExternalWebService(request);
        }

        public void CallAudatexService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Audatex);

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
