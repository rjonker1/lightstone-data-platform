using Lace.Consumer;
using Lace.Events;
using Lace.Models;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Source;
using Lace.Source.Enums;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeRgtVinSourceExecution : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly IHandleSourceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheSource _externalWebServiceCall;

        public FakeRgtVinSourceExecution(ILaceRequest request, IExecuteTheSource nextSource,
            IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _handleServiceCall = new FakeHandleRgtVinServiceCall();
            _externalWebServiceCall = new FakeCallingRgtVinExternalWebService();
        }

        public void CallSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleRgtVinServiceCall(),
                    new FakeCallingRgtVinExternalWebService());
                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.RgtResponse == null)
                    CallFallbackSource(response, laceEvent);
            }

            CallNextSource(response, laceEvent);

        }

        private static void NotHandledResponse(IProvideLaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new IvidTitleHolderResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
