using Lace.Consumer;
using Lace.Events;
using Lace.Models.Audatex;
using Lace.Models.Responses;
using Lace.Request;
using Lace.Source.Audatex.ServiceCalls;
using Lace.Source.Enums;

namespace Lace.Source.Audatex
{
    public class AudatexSourceExecution : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public AudatexSourceExecution(ILaceRequest request, IExecuteTheSource nextSource,
            IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Audatex, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleAudatexSourceCall(), new CallAudatexSource(_request));
                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.AudatexResponse == null)
                    CallFallbackSource(response, laceEvent);
            }

            CallNextSource(response, laceEvent);
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasNotBeenHandled();
        }
    }
}
