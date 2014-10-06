namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithAmortisationFactorModel
    {
        int Year { get; }
        double Value { get; }
    }
}