using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Responses.Sources
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
