using Lace.Models.Enums;

namespace Lace.Models.RgtVin
{
    public interface IResponseFromRgtVin
    {
        string Vin { get; set; }

        string VehicleMake { get; set; }

        string VehicleType { get; set; }

        string VehicleModel { get; set; }

        int? Year { get; set; }

        int? Month { get; set; }

        int? Quarter { get; set; }

        int? RgtCode { get; set; }

        decimal? Price { get; set; }

        string Colour { get; set; }

        string CarFullname { get; }

        ServiceCallState ServiceProviderCallState { get; set; }
    }
}
