using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.DataProviders.Lightstone.Services
{
    public interface IRetrieveValuationFromMetrics
    {
        bool IsSatisfied { get; }
        IRespondWithValuation Valuation { get; }
        IRetrieveValuationFromMetrics BuildValuation();
        IRetrieveValuationFromMetrics GenerateData();
    }
}
