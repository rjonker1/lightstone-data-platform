using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
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

        public ICollection<IPointToLaceProvider> GetResponsesFromLace(ILaceRequest request)
        {
            _buildSourceChain = new FakeSourceChain(request.Package.Action);
            _buildSourceChain.Build();

            if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return null;

            _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _buildSourceChain);
            _bootstrap.Execute();

            return _bootstrap.DataProviderResponses;
        }

    }
}
