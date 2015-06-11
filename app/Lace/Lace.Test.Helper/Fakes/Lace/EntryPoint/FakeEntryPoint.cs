using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Fakes.Lace.Builder;

namespace Lace.Test.Helper.Fakes.Lace.EntryPoint
{
    public class FakeEntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private IBuildSourceChain _buildSourceChain;
        private readonly IAdvancedBus _bus;
        private IBootstrap _bootstrap;

        public FakeEntryPoint()
        {
            _bus = BusFactory.WorkflowBus();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public ICollection<IPointToLaceProvider> GetResponsesFromLace(ICollection<IPointToLaceRequest> request)
        {
            _buildSourceChain = new FakeSourceChain();
            if (_checkForDuplicateRequests.IsRequestDuplicated(request.First())) return null;

            _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _buildSourceChain);
            _bootstrap.Execute();

            return _bootstrap.DataProviderResponses;
        }
    }
}