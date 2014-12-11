using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses
{
    public class RgtVinResponseBuilder
    {
        public string _vin { get; set; }

        public string _vehicleMake { get; set; }

        public string _vehicleType { get; set; }

        public string _vehicleModel { get; set; }

        public int _year { get; set; }

        public int _month { get; set; }

        public int _quarter { get; set; }

        public int _rgtCode { get; set; }

        public int _price { get; set; }

        public string _colour { get; set; }

        public string CarFullname { get; set; }
        public IProvideDataFromRgtVin Build()
        {
            return new RgtVinResponse(_colour, _month, _price, _quarter, _rgtCode, _vehicleMake, _vehicleModel, _vehicleType, _vin, _year);
        }

        public RgtVinResponseBuilder With(int month, int price, int quarter, int rgtCode, int year)
        {
            _month = month;
            _price = price;
            _quarter = quarter;
            _rgtCode = rgtCode;
            _year = year;
            return this;
        }

        public RgtVinResponseBuilder With(string color, string vehicleMake, string vechicleModel, string vehicleType, string vin)
        {
            _colour = color;
            _vehicleMake = vehicleMake;
            _vehicleModel = _vehicleModel;
            _vehicleType = vehicleType;
            _vin = vin;
            return this;
        }
    }
}