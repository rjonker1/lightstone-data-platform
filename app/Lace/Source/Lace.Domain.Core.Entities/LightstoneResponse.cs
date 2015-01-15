using System;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    public class LightstoneResponse : IProvideDataFromLightstone
    {
        public LightstoneResponse()
        {
        }

        public LightstoneResponse(int carId, int year, string vin, string imageUrl, string quarter, string carFullName,
            string model, IRespondWithValuation vehicleValuation)
        {
            CarId = carId;
            Year = year;
            Vin = vin;
            ImageUrl = imageUrl;
            Quarter = quarter;
            CarFullname = carFullName;
            Model = model;
            VehicleValuation = vehicleValuation;
        }

        public int? CarId { get; private set; }

        public int? Year { get; private set; }

        public string Vin { get; private set; }

        public string ImageUrl { get; private set; }

        public string Quarter { get; private set; }

        public string CarFullname { get; private set; }

        public string Model { get; private set; }

        public IRespondWithValuation VehicleValuation { get; private set; }
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        Type IPointToLaceProvider.Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
