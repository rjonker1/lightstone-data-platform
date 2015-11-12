using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class BmwFinanceRequest : IAmBmwFinanceRequest
    {
        public BmwFinanceRequest(IAmVinNumberRequestField vinNumber, IAmAccountNumberRequestField accountNumber, IAmIdentityNumberRequestField idNumber, IAmLicenceNumberRequestField licenseNumber, IAmEngineNumberRequestField engineNumber)
        {
            VinNumber = vinNumber;
            AccountNumber = accountNumber;
            IdNumber = idNumber;
            LicenceNumber = licenseNumber;
            EngineNumber = engineNumber;
        }

        public IAmAccountNumberRequestField AccountNumber { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }
        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmLicenceNumberRequestField LicenceNumber { get; private set; }
        public IAmEngineNumberRequestField EngineNumber { get; private set; }
    }
}
