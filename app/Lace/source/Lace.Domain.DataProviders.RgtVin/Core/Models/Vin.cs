namespace Lace.Domain.DataProviders.RgtVin.Core.Models
{
    public class Vin
    {
        public Vin()
        {
             
        }

        public Vin(string vin, int carId, string makeName, string carTypeName, string carModel, int yearId,
            string period, int month, string colour, string source)
        {
            VIN = vin;
            MakeName = makeName;
            Car_ID = carId;
            CarTypeName = carTypeName;
            CarModel = carModel;
            Year_ID = yearId;
            Period = period;
            Month = month;
            Colour = colour;
            Source = source;

        }

        public int Vin_ID { get; set; }
        public string VIN { get; set; }
        public int? Car_ID { get; set; }
        public string MakeName { get; set; }
        public string CarTypeName { get; set; }
        public string CarModel { get; set; }
        public int? Year_ID { get; set; }
        public string Period { get; set; }
        public int Month { get; set; }
        public string Colour { get; set; }
        public string Source { get; set; }
    }
}
