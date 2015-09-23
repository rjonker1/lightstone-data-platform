using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmDataProvider
    {
        DataProviderName Name { get; }
        ICollection<IAmDataProviderRequest> Request { get; }
        decimal CostPrice { get; }
        decimal RecommendedPrice { get; }
        ICauseCriticalFailure Critical { get; }
    }
}
