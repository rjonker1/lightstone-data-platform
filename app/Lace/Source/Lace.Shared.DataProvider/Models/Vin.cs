namespace Lace.Toolbox.Database.Models
{
    public class Vin
    {
        public const string SelectWithVin = "select v.* from Vin v where v.VIN = @Vin";
        //public const string SelectAll = "select v.* from Vin v";

        public const string CacheWithVinKey = "urn:Auto_Carstats:Vin:{0}";
        //public const string CacheAllKey = "urn:Auto_Carstats:Vin";

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
