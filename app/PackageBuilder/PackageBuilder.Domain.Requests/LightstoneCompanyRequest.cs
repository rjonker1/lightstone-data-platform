using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class LightstoneCompanyRequest : IAmLightstoneBusinessCompanyRequest
    {
        public LightstoneCompanyRequest(IAmCompanyNameRequestField companyName, IAmCompanyRegistrationNumberRequestField companyRegistration,
            IAmCompanyVatNumberRequestField companyVatNumber)
        {
            CompanyName = companyName;
            CompanyRegistrationNumber = companyRegistration;
            CompanyVatNumber = companyVatNumber;
        }

        public IAmCompanyNameRequestField CompanyName { get; private set; }
        public IAmCompanyRegistrationNumberRequestField CompanyRegistrationNumber { get; private set; }
        public IAmCompanyVatNumberRequestField CompanyVatNumber { get; private set; }
    }
}
