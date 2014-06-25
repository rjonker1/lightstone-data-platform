using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Builder;
using Lace.Builder.Factory;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Request.Entry;
using Lace.Request.Entry.Checks;
using Lace.Response;
using Lace.Response.ExternalServices;
using Lace.Test.Helper.Fakes.Bus;

namespace Lace.Test.Helper.Fakes.Lace.EntryPoint
{
    public class FakeEntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly IBuildSourceChain _buildSourceChain;
        private readonly ILaceEvent _laceEvent;

        public FakeEntryPoint()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _buildSourceChain = new CreateSourceChain();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            _buildSourceChain.Default(request.Package.Action);

            return !_checkForDuplicateRequests.IsRequestDuplicated(request)
                ? new Initialize(new LaceResponse(), request, _laceEvent, _buildSourceChain).LaceResponses
                : null;
        }
    }
}
