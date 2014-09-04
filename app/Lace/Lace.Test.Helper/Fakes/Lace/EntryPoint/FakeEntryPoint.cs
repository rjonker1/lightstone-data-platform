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
using Workflow;

namespace Lace.Test.Helper.Fakes.Lace.EntryPoint
{
    public class FakeEntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private IBuildSourceChain _buildSourceChain;
        private ILaceEvent _laceEvent;
        private IBootstrap _bootstrap;

        private readonly IPublishMessages _publisher;

        public FakeEntryPoint()
        {

            var bus = new FakeBus();
            _publisher = new Workflow.RabbitMQ.Publisher(bus);
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            _laceEvent = new PublishLaceEventMessages(_publisher, request.RequestAggregation.AggregateId);

            _buildSourceChain = new FakeSourceChain(request.Package.Action);
            _buildSourceChain.Build();

            if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return null;

            _bootstrap = new Initialize(new LaceResponse(), request, _laceEvent, _buildSourceChain);
            _bootstrap.Execute();

            return _bootstrap.LaceResponses;
        }
    }
}
