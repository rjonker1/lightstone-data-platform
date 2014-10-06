namespace Lace.Domain.Core.Contracts.Requests
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
