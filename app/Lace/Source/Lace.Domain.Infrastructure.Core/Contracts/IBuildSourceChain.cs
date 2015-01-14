using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IBuildSourceChain
    {
        void Build();
        Action<ILaceRequest, IBus, IProvideResponseFromLaceDataProviders> SourceChain { get; }
    }
}
