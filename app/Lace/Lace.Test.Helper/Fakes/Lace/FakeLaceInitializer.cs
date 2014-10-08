using System.Collections.Generic;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer: IBootstrap
    {
        public IList<LaceExternalSourceResponse> LaceResponses { get; private set; }

        private readonly ILaceRequest _request;

        private readonly IProvideResponseFromLaceDataProviders _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly ILaceEvent _laceEvent;

        public FakeLaceInitializer(IProvideResponseFromLaceDataProviders response, ILaceRequest request, ILaceEvent laceEvent,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _laceEvent = laceEvent;
            _response = response;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute()
        {
            _buildSourceChain.SourceChain(_request, _laceEvent, _response);

            LaceResponses = new List<LaceExternalSourceResponse>()
            {
                new LaceExternalSourceResponse() {Response = _response}
            };

        }
    }
}
