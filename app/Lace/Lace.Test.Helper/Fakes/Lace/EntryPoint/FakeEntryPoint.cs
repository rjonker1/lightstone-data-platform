
using System;
using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Fakes.Lace.Builder;
using NServiceBus;

namespace Lace.Test.Helper.Fakes.Lace.EntryPoint
{
    public class FakeEntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private IBuildSourceChain _buildSourceChain;
        private readonly IBus _bus;
        private IBootstrap _bootstrap;

        public FakeEntryPoint()
        {
            _bus = BusFactory.MonitoringBus();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            _buildSourceChain = new FakeSourceChain(request.Package.Action);
            _buildSourceChain.Build();

            if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return null;

            _bootstrap = new Initialize(new LaceResponse(), request, _bus, _buildSourceChain);
            _bootstrap.Execute();

            return _bootstrap.LaceResponses;
        }
    }
}
