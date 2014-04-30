using Lace.Models.Enums;

namespace Lace.Models.Rgt
{
    public interface IResponseFromRgt
    {
        string Manufacturer { get; set; }
        int ModelYear { get; set; }
        string ModelType { get; set; }
        string TopSpeed { get; set; }
        string Kilowatts { get; set; }
        string FuelEconomy { get; set; }
        string Acceleration { get; set; }
        string Torque { get; set; }
        string Emissions { get; set; }
        string EngineSize { get; set; }
        string BodyShape { get; set; }
        string FuelType { get; set; }
        string TransmissionType { get; set; }
        string CarFullname { get; set; }
        string Colour { get; set; }
        string RainSensorWindscreenWipers { get; set; }
        string HeadUpDisplay { get; set; }
        string VehicleType { get; set; }
        string Model { get; set; }
        string Make { get; set; }
        string CarType { get; set; }

        ServiceCallState ServiceProviderCallState { get; set; }
    }
}
