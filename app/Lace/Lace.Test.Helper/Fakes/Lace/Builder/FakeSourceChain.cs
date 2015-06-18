using System;
using System.Collections.Generic;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceChain : IBuildSourceChain
    {
        public FakeSourceChain()
        {
            SourceChain = FakeSourceSpecification.Chain();
        }

        public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> SourceChain { get; private set; }

    }
}
