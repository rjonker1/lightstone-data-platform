using Lace.Models.Enums;

namespace Lace.Models.Lightstone
{
    public interface IResponseFromLightstone
    {
        int? CarId { get; set; }

        int? Year { get; set; }

        string Vin { get; set; }

        string ImageUrl { get; set; }

        string Quarter { get; set; }

        string CarFullname { get; set; }

        string Model { get; set; }

        // Valuation VehicleValuation
        //{
        //    get;
        //    set;
        //}


        // List<CarModel> CarModels
        //{
        //    get;
        //    set;
        //}

        // List<VIN12> VIN12
        //{
        //    get;
        //    set;
        //}

        ServiceCallState ServiceProviderCallState { get; set; }
    }
}
