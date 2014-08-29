using Lace.Models.Lightstone;

namespace Lace.Source.Lightstone.Metrics
{
    public interface IRetrieveValuationFromMetrics
    {
        bool IsSatisfied { get; }
        IRespondWithValuation Valuation { get; }
        IRetrieveValuationFromMetrics SetupDataSources();
        IRetrieveValuationFromMetrics BuildValuation();
        IRetrieveValuationFromMetrics GenerateData();
    }
}
