namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveVehicle
    {
       // IAmRequestField RequestField { get; }
        string EngineNo { get; }
        string VinOrChassis { get; }
        string Make { get; }
        string RegisterNo { get; }
        string LicenceNo { get; }
        string Vin { get; }

        //void SetVinNumber(string vinNumber);
        //void SetLicenseNo(string licenceNo);
        //void SetMake(string make);

    }
}
