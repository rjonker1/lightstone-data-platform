namespace Lace.Models.Lightstone
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