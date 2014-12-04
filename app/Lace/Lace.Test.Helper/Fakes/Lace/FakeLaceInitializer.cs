using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer: IBootstrap
    {
        public IList<LaceExternalSourceResponse> LaceResponses { get; private set; }

        private readonly ILaceRequest _request;

        private readonly IProvideResponseFromLaceDataProviders _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly ISendMonitoringMessages _monitoring;

        public FakeLaceInitializer(IProvideResponseFromLaceDataProviders response, ILaceRequest request, ISendMonitoringMessages monitoring,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _monitoring = monitoring;
            _response = response;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute()
        {
            _buildSourceChain.SourceChain(_request, _monitoring, _response);

            LaceResponses = new List<LaceExternalSourceResponse>()
            {
                new LaceExternalSourceResponse() {Response = _response}
            };

        }
    }
}
