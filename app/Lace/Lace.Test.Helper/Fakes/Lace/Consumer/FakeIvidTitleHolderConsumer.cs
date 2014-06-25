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
    public class FakeIvidTitleHolderConsumer : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public FakeIvidTitleHolderConsumer(ILaceRequest request, IExecuteTheSource nextSource,
            IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.IvidTitleHolder, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeService(new FakeHandleIvidTitleHolderServiceCall(),
                    new FakeCallingIvidTitleHolderExternalWebService());
                consumer.CallService(response, laceEvent);

                if (response.IvidTitleHolderResponse == null && FallBack != null)
                    FallBack.CallSource(response, laceEvent);
            }

            if (Next != null) Next.CallSource(response, laceEvent);
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasNotBeenHandled();
        }
    }
}
