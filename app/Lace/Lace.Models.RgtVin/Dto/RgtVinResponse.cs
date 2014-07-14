namespace Lace.Models.RgtVin.Dto
{
    public class RgtVinResponse : IResponseFromRgtVin
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

        public void BuidWithValidation(string color, string month, string price, string quarter, string rgtCode,
            string vehicleMake, string vechicleModel, string vehicleType, string vin, string year)
        {
            Colour = color;
            Month = ValidateNumber(month);
            Price = ValidateNumber(price);
            Quarter = ValidateNumber(quarter);
            RgtCode = ValidateNumber(rgtCode);
            VehicleMake = vehicleMake;
            VehicleModel = vechicleModel;
            VehicleType = vehicleType;
            Vin = vin;
            Year = ValidateNumber(year);
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

        private static int ValidateNumber(string number)
        {
            if (string.IsNullOrEmpty(number)) return 0;

            int num;

            int.TryParse(number, out num);

            return num;
        }
    }
}
