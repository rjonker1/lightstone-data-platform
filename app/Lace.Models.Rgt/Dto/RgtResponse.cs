using Lace.Models.Enums;

namespace Lace.Models.Rgt.Dto
{
    public class RgtResponse : IResponseFromRgt
    {

        public string Manufacturer { get; set; }

        public int ModelYear { get; set; }

        public string ModelType { get; set; }

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

        public string Model { get; set; }

        public string Make { get; set; }

        public string CarType { get; set; }

        public ServiceCallState ServiceProviderCallState { get; set; }
    }
}
