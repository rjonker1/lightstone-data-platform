namespace Lace.Models.Responses.Sources.Specifics
{
    public interface IRespondWithAreaFactorModel
    {
        string Municipality { get; }
        int Index { get; }
        double Value { get; }
    }
}