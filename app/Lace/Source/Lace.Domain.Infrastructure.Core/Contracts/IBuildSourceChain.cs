using System;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IBuildSourceChain
    {
        void Build();
        Action<ILaceRequest, ILaceEvent, IProvideResponseFromLaceDataProviders> SourceChain { get; }
    }
}
