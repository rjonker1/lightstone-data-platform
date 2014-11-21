using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.Builder;
using Workflow;

namespace Lace.Test.Helper.Fakes.Lace.EntryPoint
{
    public class FakeEntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private IBuildSourceChain _buildSourceChain;
        private ISendMonitoringMessages _monitoring;
        private IBootstrap _bootstrap;

        private readonly IPublishMessages _publisher;

        public FakeEntryPoint()
        {

            var bus = new FakeBus();
            _publisher = new Workflow.RabbitMQ.Publisher(bus);
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            //_monitoring = new PublishLaceEventMessages(_publisher, request.RequestAggregation.AggregateId);

            _buildSourceChain = new FakeSourceChain(request.Package.Action);
            _buildSourceChain.Build();

            if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return null;

            _bootstrap = new Initialize(new LaceResponse(), request, _monitoring, _buildSourceChain);
            _bootstrap.Execute();

            return _bootstrap.LaceResponses;
        }
    }
}
