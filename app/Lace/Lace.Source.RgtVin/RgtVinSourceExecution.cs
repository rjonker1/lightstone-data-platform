using Lace.Consumer;
using Lace.Events;
using Lace.Models.RgtVin;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;
using Lace.Source.RgtVin.ServiceCalls;

namespace Lace.Source.RgtVin
{
    public class RgtVinSourceExecution : ExecuteSourceBase,  IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public RgtVinSourceExecution(ILaceRequest request, IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleRgtVinSourceCall(), new CallRgtVinExternalSource(_request));
                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.RgtVinResponse == null && FallBack != null)
                    FallBack.CallSource(response, laceEvent);
            }

            if (Next != null) Next.CallSource(response, laceEvent);

        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
