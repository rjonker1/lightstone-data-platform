namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithRepairIndexModel
    {
        int Year { get; }
        string Band { get; }
        double Value { get; }
    }
}