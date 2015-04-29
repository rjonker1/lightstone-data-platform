using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class Initialize : IBootstrap
    {
        public ICollection<IPointToLaceProvider> DataProviderResponses { get; private set; }
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly IAdvancedBus _bus;

        public Initialize(ICollection<IPointToLaceProvider> responses, ICollection<IPointToLaceRequest> request,
            IAdvancedBus bus,
            IBuildSourceChain buildSourceChain)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _bus = bus;
            DataProviderResponses = responses;
            _buildSourceChain = buildSourceChain;
        }


        public void Execute()
        {
            if (_buildSourceChain.SourceChain == null)
            {
                _log.Error("Source chain for request is null and cannot be executed");
                throw new Exception("Source Chain cannot be null");
            }

            _buildSourceChain.SourceChain(_request, _bus, DataProviderResponses,
                _request.First().Request.RequestId);
        }
    }
}
