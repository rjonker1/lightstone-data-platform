namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithAuctionFactorModel
    {
        string Make { get; }
        decimal Value { get; }
    }
}