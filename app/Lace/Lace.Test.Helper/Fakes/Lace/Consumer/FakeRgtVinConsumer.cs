

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
    public class FakeRgtVinConsumer : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly IHandleSourceCall _handleServiceCall;
        private readonly ILaceRequest _request;
        private readonly ICallTheSource _externalWebServiceCall;

        public FakeRgtVinConsumer(ILaceRequest request, IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _handleServiceCall = new FakeHandleRgtVinServiceCall();
            _externalWebServiceCall = new FakeCallingRgtVinExternalWebService();
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.RgtVin,_request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeService(new FakeHandleRgtVinServiceCall(),
                    new FakeCallingRgtVinExternalWebService());
                consumer.CallService(response, laceEvent);

                if (response.RgtResponse == null && FallBack != null)
                    FallBack.CallSource(response, laceEvent);
            }

            if (Next != null) Next.CallSource(response, laceEvent);

            //_handleServiceCall
            //    .Request(c =>
            //        c.FetchDataFromService(response, _externalWebServiceCall, laceEvent)
            //    );
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new IvidTitleHolderResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
