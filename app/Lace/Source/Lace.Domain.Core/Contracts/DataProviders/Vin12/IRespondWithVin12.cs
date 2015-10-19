using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Vin12
{
    public interface IRespondWithVin12 : IProvideType
    {
        int CarId { get; }
        int Year { get; }
        string CarFullName { get; }
        string ImageUrl { get; }
        string BodyShape { get; }
        string Make { get; }
    }
}
