using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class LightstoneBusinessCompanyRequest : IAmLightstoneBusinessCompanyRequest
    {
        private LightstoneBusinessCompanyRequest()
        {
            
        }

        public static LightstoneBusinessCompanyRequest WithDefault(string companyName, string companyRegNumber, string companyVatNumber)
        {
            return new LightstoneBusinessCompanyRequest()
            {
                CompanyName = CompanyNameRequestField.Get(companyName),
                CompanyRegistrationNumber = CompanyRegistrationNumberRequestField.Get(companyRegNumber),
                CompanyVatNumber = CompanyVatNumberRequestField.Get(companyVatNumber)
            };
        }


        public IAmCompanyNameRequestField CompanyName { get; private set; }

        public IAmCompanyRegistrationNumberRequestField CompanyRegistrationNumber { get; private set; }

        public IAmCompanyVatNumberRequestField CompanyVatNumber { get; private set; }
    }
}
