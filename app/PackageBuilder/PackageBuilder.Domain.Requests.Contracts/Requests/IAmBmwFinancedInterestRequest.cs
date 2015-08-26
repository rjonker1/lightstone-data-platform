using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmBmwFinancedInterestRequest : IAmDataProviderRequest
    {
        IAmAccountNumberField AccountNumber { get; }
        IAmVinNumberRequestField VinNumber { get; }
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmLicenceNumberRequestField LicenceNumber { get; }
    }
}
