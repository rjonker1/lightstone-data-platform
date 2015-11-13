using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class LightstoneBusinessDirectorRequest : IAmLightstoneBusinessDirectorRequest
    {
        private LightstoneBusinessDirectorRequest()
        {
            
        }

        public static LightstoneBusinessDirectorRequest WithDefault(string firstName, string surname, long idNumber)
        {
            return new LightstoneBusinessDirectorRequest()
            {
                FirstName = FirstNameRequestField.Get(firstName),
                Surname = SurnameRequestField.Get(surname),
                IdNumber = IdentityNumberRequestField.Get(idNumber.ToString())
            };
        }
        public IAmCompanyVatNumberRequestField CompanyVatNumber { get; private set; }

        public IAmFirstNameRequestField FirstName { get; private set; }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }

        public IAmSurnameRequestField Surname { get; private set; }
    }
}
