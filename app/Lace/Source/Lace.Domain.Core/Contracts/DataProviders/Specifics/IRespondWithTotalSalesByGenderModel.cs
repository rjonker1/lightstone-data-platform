namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithTotalSalesByGenderModel
    {
        string CarType { get; }
        string Band { get; }
        double Value { get; }
    }
}