namespace Lace.Models.Responses.Sources.Specifics
{
    public interface IRespondWithImageGaugeModel
    {
        double? MinValue { get; }
        double? MaxValue { get; }
        double? Value { get; }
        double? Quarter { get; }
        string GaugeName { get; }
    }
}