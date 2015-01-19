using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
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

        [DataMember]
        public string Vin { get; private set; }
        [DataMember]
        public string VehicleMake { get; private set; }
        [DataMember]
        public string VehicleType { get; private set; }
        [DataMember]
        public string VehicleModel { get; private set; }
        [DataMember]
        public int? Year { get; private set; }
        [DataMember]
        public int? Month { get; private set; }
        [DataMember]
        public int? Quarter { get; private set; }
        [DataMember]
        public int? RgtCode { get; private set; }
        [DataMember]
        public decimal? Price { get; private set; }
        [DataMember]
        public string Colour { get; private set; }
        [DataMember]
        public string CarFullname { get; private set; }
        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
