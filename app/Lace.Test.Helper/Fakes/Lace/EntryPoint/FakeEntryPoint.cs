using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Request.Entry;
using Lace.Request.Entry.Checks;
using Lace.Response.ExternalServices;
using Lace.Test.Helper.Builders.RequestedTypes;
using Lace.Test.Helper.Fakes.Bus;

namespace Lace.Test.Helper.Fakes.Lace.EntryPoint
{
    public class FakeEntryPoint: IEntryPoint
    {

        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly IGetRequiredRequestedTypes _getRequestedType;
        private readonly ILaceEvent _laceEvent;

        public FakeEntryPoint()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _getRequestedType = new RequestedTypeBuilder().ForLicensePlateNumber();
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
