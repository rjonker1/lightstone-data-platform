namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithSaleModel
    {
        string SalesDate { get; }
        string LicensingDistrict { get; }
        string SalesPrice { get; }
    }
}
