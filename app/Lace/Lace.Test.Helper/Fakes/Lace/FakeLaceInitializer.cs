using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer: IBootstrap
    {
        public IList<LaceExternalSourceResponse> LaceResponses { get; private set; }

        private readonly ILaceRequest _request;

        private readonly IProvideResponseFromLaceDataProviders _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly IBus _bus;

        public FakeLaceInitializer(IProvideResponseFromLaceDataProviders response, ILaceRequest request, IBus bus,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _bus = bus;
            _response = response;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute()
        {
            _buildSourceChain.SourceChain(_request, _bus, _response, _request.RequestAggregation.AggregateId);

            LaceResponses = new List<LaceExternalSourceResponse>()
            {
                new LaceExternalSourceResponse() {Response = _response}
            };

        }
    }
}
