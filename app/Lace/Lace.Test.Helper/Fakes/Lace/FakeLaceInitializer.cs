using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using NServiceBus;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer : IBootstrap
    {
        private readonly ILaceRequest _request;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly IBus _bus;

        public FakeLaceInitializer(ICollection<IPointToLaceProvider> response, ILaceRequest request, IBus bus,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _bus = bus;
            DataProviderResponses = response;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute()
        {
            _buildSourceChain.SourceChain(_request, _bus, DataProviderResponses, _request.RequestAggregation.AggregateId);
        }


        public ICollection<Domain.Core.Contracts.Requests.IPointToLaceProvider> DataProviderResponses { get;
            private set; }
    }
}
