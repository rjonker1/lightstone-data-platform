using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithEstimatedValueModel : IProvideType
    {
        string RetailEstimatedValue { get; }
        string RetailEstimatedLow { get; }
        string RetailEstimatedHigh { get; }
        string RetailConfidenceValue { get; }
        string RetailConfidenceLevel { get; }

        string TradeEstimatedValue { get; }
        string TradeEstimatedLow { get; }
        string TradeEstimatedHigh { get; }
        string TradeConfidenceValue { get; }
        string TradeConfidenceLevel { get; }

        void SetTradeEstimatedValues(string tradeEstimatedValue, string tradeEstimatedLow, string tradeEstimatedHigh,
            string tradeConfidenceValue, string tradeConfidenceLevel);

        void SetRetailEstimatedValues(string retailEstimatedValue, string retailEstimatedLow, string retailEstimatedHigh,
            string retailConfidenceValue, string retailConfidenceLevel);
    }
}