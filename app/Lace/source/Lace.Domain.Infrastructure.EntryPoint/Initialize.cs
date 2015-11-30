using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public sealed class Initialize : IBootstrap
    {
        public ICollection<IPointToLaceProvider> DataProviderResponses { get; private set; }
        private static readonly ILog Log = LogManager.GetLogger<Initialize>();
        private readonly ICollection<IPointToLaceRequest> _request;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly IAdvancedBus _bus;

        public Initialize(ICollection<IPointToLaceProvider> responses, ICollection<IPointToLaceRequest> request, IAdvancedBus bus,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _bus = bus;
            DataProviderResponses = responses;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute(ChainType chain)
        {
            _buildSourceChain.Build(chain)(_request, _bus, DataProviderResponses,_request.First().Request.RequestId);
        }
    }
}
