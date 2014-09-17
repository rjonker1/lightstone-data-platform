namespace Lace.Models.Responses.Sources.Specifics
{
    public interface IRespondWithConfidenceModel
    {
        string CarType { get; }
        int Year { get; }
        double Value { get; }
    }
}
