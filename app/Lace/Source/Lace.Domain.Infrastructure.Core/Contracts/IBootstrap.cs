using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IBootstrap
    {
        ICollection<IPointToLaceProvider> DataProviderResponses { get; }
        void Execute(ChainType chain);
    }
}