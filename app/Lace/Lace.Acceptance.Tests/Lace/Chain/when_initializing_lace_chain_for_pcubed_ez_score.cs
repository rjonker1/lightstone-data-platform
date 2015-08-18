using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_initializing_lace_chain_for_pcubed_ez_score : Specification
    {
        private IBootstrap _initialize;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _command;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_chain_for_pcubed_ez_score()
        {
            _command = BusFactory.WorkflowBus();
            _request = new PCubedRequestBuilder().ForEzScore();
            _buildSourceChain = new CreateSourceChain();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _command, _buildSourceChain);
            _initialize.Execute();
        }
    }
}
