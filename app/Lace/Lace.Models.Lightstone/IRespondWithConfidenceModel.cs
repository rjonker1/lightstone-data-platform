namespace Lace.Models.Lightstone
{
    public interface IRespondWithConfidenceModel
    {
        string CarType { get; }
        int Year { get; }
        double Value { get; }
    }
}
