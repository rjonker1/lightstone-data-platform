using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Shared.Extensions;
using NServiceBus;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer : IBootstrap
    {
        private readonly ICollection<IPointToLaceRequest> _request;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly IBus _bus;

        public FakeLaceInitializer(ICollection<IPointToLaceProvider> response, ICollection<IPointToLaceRequest> request, IBus bus,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _bus = bus;
            DataProviderResponses = response;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute()
        {
            _buildSourceChain.SourceChain(_request, _bus, DataProviderResponses, _request.First().Aggregation.AggregateId);
        }


        public ICollection<Domain.Core.Contracts.Requests.IPointToLaceProvider> DataProviderResponses { get;
            private set; }
    }
}
