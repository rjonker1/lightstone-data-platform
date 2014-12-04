using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    public class RgtResponse : IProvideDataFromRgt
    {
        public RgtResponse()
        {
        }

        public RgtResponse(string manufacturer, int modelYear, string modelType, string topSpeed, string kilowatts, string fuelEconomy,
            string acceleration, string torque, string emissions,
            string engineSize, string bodyShape, string fuelType, string transmissionType, string carFullName,
            string colour, string rainSensorWipers, string headsUpDisplay,
            string vehicleType, string model, string make, string carType)
        {
            Manufacturer = manufacturer;
            ModelYear = modelYear;
            ModelType = modelType;
            TopSpeed = topSpeed;
            Kilowatts = kilowatts;
            FuelEconomy = fuelEconomy;
            Acceleration = acceleration;
            Torque = torque;
            Emissions = emissions;
            EngineSize = engineSize;
            BodyShape = bodyShape;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            CarFullname = carFullName;
            Colour = colour;
            RainSensorWindscreenWipers = rainSensorWipers;
            HeadUpDisplay = headsUpDisplay;
            VehicleType = vehicleType;
            Model = model;
            Make = make;
            CarType = carType;
        }


        public string Manufacturer { get; private set; }

        public int ModelYear { get; private set; }

        public string ModelType { get; private set; }

        public string TopSpeed { get; private set; }

        public string Kilowatts { get; private set; }

        public string FuelEconomy { get; private set; }

        public string Acceleration { get; private set; }

        public string Torque { get; private set; }

        public string Emissions { get; private set; }

        public string EngineSize { get; private set; }

        public string BodyShape { get; private set; }

        public string FuelType { get; private set; }

        public string TransmissionType { get; private set; }

        public string CarFullname { get; private set; }

        public string Colour { get; private set; }

        public string RainSensorWindscreenWipers { get; private set; }

        public string HeadUpDisplay { get; private set; }

        public string VehicleType { get; private set; }

        public string Model { get; private set; }

        public string Make { get; private set; }

        public string CarType { get; private set; }
    }
}
