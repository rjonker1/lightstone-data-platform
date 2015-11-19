using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmBmwFinanceRequest : IAmDataProviderRequest
    {
        IAmAccountNumberRequestField AccountNumber { get; }
        IAmVinNumberRequestField VinNumber { get; }
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmLicenceNumberRequestField LicenceNumber { get; }
        IAmEngineNumberRequestField EngineNumber { get; }
    }
}
