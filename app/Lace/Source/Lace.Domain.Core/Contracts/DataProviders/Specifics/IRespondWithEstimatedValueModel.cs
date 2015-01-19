using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithEstimatedValueModel : IProvideType
    {
        string EstimatedValue { get; }
        string EstimatedLow { get; }
        string EstimatedHigh { get; }
        string ConfidenceValue { get; }
        string ConfidenceLevel { get; }
    }
}