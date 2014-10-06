using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstone : IPointToLaceProvider
    {
        int? CarId { get; }

        int? Year { get; }

        string Vin { get; }

        string ImageUrl { get; }

        string Quarter { get; }

        string CarFullname { get; }

        string Model { get; }

        IRespondWithValuation VehicleValuation { get; }
    }
}
