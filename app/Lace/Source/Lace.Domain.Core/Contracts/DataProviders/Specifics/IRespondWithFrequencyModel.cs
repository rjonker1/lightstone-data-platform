namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithFrequencyModel
    {
        string CarType { get; }
        int Year { get; }
        double Value { get; }
    }
}