using Lace.Consumer;
using Lace.Events;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.ServiceCalls;
using Lace.Source.Enums;

namespace Lace.Source.Audatex
{
    public class AudatexConsumer : IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public AudatexConsumer(ILaceRequest request)
        {
            _request = request;
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Audatex, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
                return;
            }

            var consumer = new ConsumeService(new HandleAudatexSourceCall(), new CallAudatexSource(_request));
            consumer.CallService(response, laceEvent);
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasNotBeenHandled();
        }
    }
}
