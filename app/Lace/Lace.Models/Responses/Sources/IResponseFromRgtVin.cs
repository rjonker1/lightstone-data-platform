namespace Lace.Models.Responses.Sources
{
    public interface IResponseFromRgtVin : IPointToLaceSource
    {
        string Vin { get; }

        string VehicleMake { get; }

        string VehicleType { get; }

        string VehicleModel { get; }

        int? Year { get; }

        int? Month { get; }

        int? Quarter { get; }

        int? RgtCode { get; }

        decimal? Price { get; }

        string Colour { get; }

        string CarFullname { get; }
    }
}
