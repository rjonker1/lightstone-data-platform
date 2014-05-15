using System.Collections.Generic;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request.Entry;
using Lace.Request.Entry.Checks;
using Lace.Response.ExternalServices;
using Lace.Tests.Data.Fakes;

namespace Lace.Request.Tests.Data.EntryPointData
{
    public class MockEntryPoint : IEntryPoint
    {

        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly IGetRequiredRequestedTypes _getRequestedType;
        private readonly ILaceEvent _laceEvent;

        public MockEntryPoint()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _getRequestedType = new MockGetRequestedTypeToLoad();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }


        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            GetRequestedTypeToLoad(request);

            return !_checkForDuplicateRequests.IsRequestDuplicated(request)
                ? new Initialize(request, _getRequestedType.RequestedTypeToLoad, _laceEvent).LaceResponses
                : null;
        }

        private void GetRequestedTypeToLoad(ILaceRequest request)
        {
            _getRequestedType.GetRequestedType(request);
        }
    }
}
