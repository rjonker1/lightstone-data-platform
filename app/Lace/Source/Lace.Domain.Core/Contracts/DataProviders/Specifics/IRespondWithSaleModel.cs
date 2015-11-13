using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithSaleModel : IProvideType
    {
        string SalesDate { get; }
        string LicensingDistrict { get; }
        string SalesPrice { get; }
    }
}
