using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class BmwFinanceRequest : IAmBmwFinanceRequest
    {
        public static BmwFinanceRequest WithDefault(string vinNumber, string idNumber, string licenseNumber, string accountNumber, string engineNumber)
        {
            return new BmwFinanceRequest()
            {
                IdNumber = IdentityNumberRequestField.Get(idNumber),
                LicenceNumber = LicenceNumberField.Get(licenseNumber),
                VinNumber =  VinNumberRequestField.Get(vinNumber),
                AccountNumber = AccountNumberRequestField.Get(accountNumber),
                EngineNumber = EngineNumberField.Get(engineNumber)
            };
        }

        public IAmAccountNumberRequestField AccountNumber { get; private set; }
        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmLicenceNumberRequestField LicenceNumber { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }
        public IAmEngineNumberRequestField EngineNumber { get; private set; }
    }
}
 