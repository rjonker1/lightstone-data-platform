using Lace.Consumer;
using Lace.Events;
using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;
using Lace.Source.Ivid.ServiceCalls;

namespace Lace.Source.Ivid
{
    public class IvidConsumer : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public IvidConsumer(ILaceRequest request, IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Ivid,_request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeService(new HandleIvidSourceCall(), new CallIvidExternalSource(_request));
                consumer.CallService(response, laceEvent);

                if(response.IvidResponse == null && FallBack != null)
                    FallBack.CallSource(response, laceEvent);
            }

            if (Next != null) Next.CallSource(response, laceEvent);
        }


        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasNotBeenHandled();
        }
    }
}
