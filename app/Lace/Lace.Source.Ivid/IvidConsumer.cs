using Lace.Consumer;
using Lace.Events;
using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;
using Lace.Source.Ivid.ServiceCalls;

namespace Lace.Source.Ivid
{
    public class IvidConsumer
    {
        private readonly ILaceRequest _request;

        public IvidConsumer(ILaceRequest request)
        {
            _request = request;
         
        }

        public void CallIvidService(ILaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Ivid,_request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
                return;
            }

            var consumer = new ConsumeService(new HandleIvidSourceCall(), new CallIvidExternalSource(_request));
            consumer.CallService(response, laceEvent);
        }


        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasNotBeenHandled();
        }

    }
}
