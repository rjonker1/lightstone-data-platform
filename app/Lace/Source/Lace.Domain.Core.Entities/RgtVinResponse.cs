using System;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    public class RgtVinResponse : IProvideDataFromRgtVin
    {
        public RgtVinResponse()
        {
        }

        public RgtVinResponse(string color, int month, int price, int quarter, int rgtCode, string vehicleMake,
            string vechicleModel, string vehicleType, string vin, int year)
        {
            Colour = color;
            Month = month;
            Price = price;
            Quarter = quarter;
            RgtCode = rgtCode;
            VehicleMake = vehicleMake;
            VehicleModel = vechicleModel;
            VehicleType = vehicleType;
            Vin = vin;
            Year = year;
        }

        public void SetCarName()
        {
            CarFullname = string.Format("{0} {1}", VehicleMake, VehicleModel);
        }

        public string Vin { get; private set; }

        public string VehicleMake { get; private set; }

        public string VehicleType { get; private set; }

        public string VehicleModel { get; private set; }

        public int? Year { get; private set; }

        public int? Month { get; private set; }

        public int? Quarter { get; private set; }

        public int? RgtCode { get; private set; }

        public decimal? Price { get; private set; }

        public string Colour { get; private set; }

        public string CarFullname { get; private set; }

        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
