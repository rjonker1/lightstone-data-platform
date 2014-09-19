namespace Lace.Request
{
    public interface IProvideVehicleInformationForRequest
    {
        string EngineNo { get; }
        string VinOrChassis { get; }
        string Make { get; }
        string RegisterNo { get; }
        string LicenceNo { get; }
        string Vin { get; }

    }
}
