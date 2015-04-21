using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmDataProvider
    {
        DataProviderName Name { get; }
        IAmDataProviderRequest DataProviderRequest { get; }
        decimal CostPrice { get; }
        decimal RecommendedPrice { get; }
    }
}
