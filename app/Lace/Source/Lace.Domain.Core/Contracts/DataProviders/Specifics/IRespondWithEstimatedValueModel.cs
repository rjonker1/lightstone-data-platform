namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithEstimatedValueModel
    {
        string EstimatedValue { get; }
        string EstimatedLow { get; }
        string EstimatedHigh { get; }
        string ConfidenceValue { get; }
        string ConfidenceLevel { get; }
    }
}