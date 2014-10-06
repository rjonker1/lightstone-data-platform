namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithAmortisedValueModel
    {
        string Year { get; }
        decimal Value { get; }
    }
}
