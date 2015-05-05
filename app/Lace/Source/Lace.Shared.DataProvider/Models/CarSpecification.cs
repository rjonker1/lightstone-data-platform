using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class CarSpecification : IAmCachable
    {
        public const string SelectWithCarId =
            "select c.CarModel, c.ModelYear,m.ManufacturerName, ct.CarTypeName, c.EngineSize, c.BodyShape, c.FuelType, c.TransmissionType, c.CarFullName, c.RainSensorWindscreenWipers, c.HeadUpDisplay from Car c join Manufacturer m on m.Manufacturer_ID = c.Manufacturer_ID join CarType ct on ct.CarType_ID = c.CarType_ID where c.Car_ID = @CarId";

        public const string SelectAll =
            @"select c.CarModel, c.ModelYear,m.ManufacturerName, ct.CarTypeName, c.EngineSize, c.BodyShape, c.FuelType, c.TransmissionType, c.CarFullName, c.RainSensorWindscreenWipers, c.HeadUpDisplay from Car c join Manufacturer m on m.Manufacturer_ID = c.Manufacturer_ID join CarType ct on ct.CarType_ID = c.CarType_ID";

        public const string CacheAllKey = "urn:Auto_Carstats:CarSpecifications";
        public const string CacheWithCarIdKey = "urn:Auto_Carstats:CarSpecifications:{0}";

        public CarSpecification()
        {
            
        }

        public CarSpecification(string manufacturerName, int modelYear, string carTypeName, string topSpeed, string kilowatts,
            string fuelEconomy, string accelration, string torque, string emissions, string engineSize, string bodyShape,
            string fuelType, string transmissionType, string carFullName, string color,
            string rainSensorWindscreenWipers, string headsUpDisplay, string vehicleType, string carModel, string make,
            string carType)
        {
            ManufacturerName = manufacturerName;
            ModelYear = modelYear;
            CarTypeName = carTypeName;
            TopSpeed = topSpeed;
            Kilowatts = kilowatts;
            FuelEconomy = fuelEconomy;
            Acceleration = accelration;
            Torque = torque;
            Emissions = emissions;
            EngineSize = engineSize;
            BodyShape = bodyShape;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            CarFullname = carFullName;
            Colour = color;
            RainSensorWindscreenWipers = rainSensorWindscreenWipers;
            HeadUpDisplay = headsUpDisplay;
            VehicleType = vehicleType;
            CarModel = carModel;
            Make = make;
            CarType = carType;
        }

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<CarSpecification>(SelectAll, CacheAllKey);
        }

        public string ManufacturerName { get; set; }
        public int? ModelYear { get; set; }
        public string CarTypeName { get; set; }
        public string TopSpeed { get; set; }
        public string Kilowatts { get; set; }
        public string FuelEconomy { get; set; }
        public string Acceleration { get; set; }
        public string Torque { get; set; }
        public string Emissions { get; set; }
        public string EngineSize { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string CarFullname { get; set; }
        public string Colour { get; set; }
        public string RainSensorWindscreenWipers { get; set; }
        public string HeadUpDisplay { get; set; }
        public string VehicleType { get; set; }
        public string CarModel { get; set; }
        public string Make { get; set; }
        public string CarType { get; set; }
    }
}