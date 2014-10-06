namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithConfidenceModel
    {
        string CarType { get; }
        int Year { get; }
        double Value { get; }
    }
}
