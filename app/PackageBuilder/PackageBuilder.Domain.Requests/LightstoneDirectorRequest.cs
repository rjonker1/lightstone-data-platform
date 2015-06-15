using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class LightstoneDirectorRequest : IAmLightstoneBusinessDirectorRequest
    {
        public LightstoneDirectorRequest(IAmIdentityNumberRequestField idNumber, IAmFirstNameRequestField firstName,
           IAmSurnameRequestField surname)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            Surname = surname;
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmFirstNameRequestField FirstName { get; private set; }
        public IAmSurnameRequestField Surname { get; private set; }
    }
}
