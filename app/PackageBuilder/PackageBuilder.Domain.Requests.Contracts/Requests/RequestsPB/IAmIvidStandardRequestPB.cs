using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests.RequestsPB
{
    public interface IAmIvidStandardRequestPb : IAmIvidStandardRequest
    {
        IAmEngineNumberRequestField EngineNumber { get; }
        IAmChassisNumberRequestField ChassisNumber { get; }
        IAmVinNumberRequestField VinNumber { get; }
        IAmLicenceNumberRequestField LicenceNumber { get; }
        IAmRegisterNumberRequestField RegisterNumber { get; }
        IAmMakeRequestField Make { get; } 
    }
}