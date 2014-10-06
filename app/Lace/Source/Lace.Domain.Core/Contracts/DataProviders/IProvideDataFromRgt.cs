using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromRgt : IPointToLaceProvider
    {
        string Manufacturer { get; }
        int ModelYear { get; }
        string ModelType { get; }
        string TopSpeed { get; }
        string Kilowatts { get; }
        string FuelEconomy { get; }
        string Acceleration { get; }
        string Torque { get; }
        string Emissions { get; }
        string EngineSize { get; }
        string BodyShape { get; }
        string FuelType { get; }
        string TransmissionType { get; }
        string CarFullname { get; }
        string Colour { get; }
        string RainSensorWindscreenWipers { get; }
        string HeadUpDisplay { get; }
        string VehicleType { get; }
        string Model { get; }
        string Make { get; }
        string CarType { get; }
    }
}
