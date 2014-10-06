namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithPriceModel
    {
        string Name { get; }
        decimal Value { get; }
    }
}