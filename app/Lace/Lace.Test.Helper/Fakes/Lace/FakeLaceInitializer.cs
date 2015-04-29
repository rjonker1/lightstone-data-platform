using System.Collections.Generic;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer : IBootstrap
    {
        private readonly ICollection<IPointToLaceRequest> _request;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly IAdvancedBus _bus;

        public FakeLaceInitializer(ICollection<IPointToLaceProvider> response, ICollection<IPointToLaceRequest> request, IAdvancedBus bus,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _bus = bus;
            DataProviderResponses = response;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute()
        {
            _buildSourceChain.SourceChain(_request, _bus, DataProviderResponses, _request.First().Request.RequestId);
        }


        public ICollection<Domain.Core.Contracts.Requests.IPointToLaceProvider> DataProviderResponses { get;
            private set; }
    }
}
