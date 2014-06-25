using System.Collections.Generic;
using Lace.Builder;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Request.Entry;
using Lace.Request.Entry.Checks;
using Lace.Response;
using Lace.Response.ExternalServices;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.Builder;

namespace Lace.Test.Helper.Fakes.Lace.EntryPoint
{
    public class FakeEntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly IBuildSourceChain _buildSourceChain;
        private readonly ILaceEvent _laceEvent;
        private IBootstrap _bootstrap;

        public FakeEntryPoint()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _buildSourceChain = new FakeSourceChain();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            _buildSourceChain.Default(request.Package.Action);

            if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return null;

            _bootstrap = new Initialize(new LaceResponse(), request, _laceEvent, _buildSourceChain);
            _bootstrap.Execute();

            return _bootstrap.LaceResponses;
        }
    }
}
