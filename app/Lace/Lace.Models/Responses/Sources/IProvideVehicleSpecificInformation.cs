namespace Lace.Models.Responses.Sources
{
    public interface IProvideVehicleSpecificInformation : IPointToLaceProvider
    {
        string Odometer { get; }
        string Colour { get; }
        string RegistrationNumber { get; }
        string VinNumber { get; }
        string LicenseNumber { get; }
        string EngineNumber { get; }
        string CategoryDescription { get; }
    }
}