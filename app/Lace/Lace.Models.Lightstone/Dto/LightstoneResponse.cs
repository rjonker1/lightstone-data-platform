using System.Collections.Generic;

namespace Lace.Models.Lightstone.Dto
{
    public class LightstoneResponse : IResponseFromLightstone
    {
        public LightstoneResponse()
        {
        }

        public LightstoneResponse(int carId, int year, string vin, string imageUrl, string quarter, string carFullName,
            string model, IRespondWithValuation vehicleValuation, IEnumerable<IRespondWithCarModel> carModels,
            IEnumerable<IRespondWithVin12> vin12)
        {
            CarId = carId;
            Year = year;
            Vin = vin;
            ImageUrl = imageUrl;
            Quarter = quarter;
            CarFullname = carFullName;
            Model = model;
            VehicleValuation = vehicleValuation;
            CarModels = carModels;
            Vin12 = vin12;
        }

        public int? CarId { get; private set; }

        public int? Year { get; private set; }

        public string Vin { get; private set; }

        public string ImageUrl { get; private set; }

        public string Quarter { get; private set; }

        public string CarFullname { get; private set; }

        public string Model { get; private set; }

        public IRespondWithValuation VehicleValuation { get; private set; }

        public IEnumerable<IRespondWithCarModel> CarModels { get; private set; }

        public IEnumerable<IRespondWithVin12> Vin12 { get; private set; }
    }
}
