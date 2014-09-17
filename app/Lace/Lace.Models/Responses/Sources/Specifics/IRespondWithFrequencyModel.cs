namespace Lace.Models.Responses.Sources.Specifics
{
    public interface IRespondWithFrequencyModel
    {
        string CarType { get; }
        int Year { get; }
        double Value { get; }
    }
}