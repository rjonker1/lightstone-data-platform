using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class PCubedEzScoreRequest : IAmPCubedEzScoreRequest
    {
        private PCubedEzScoreRequest()
        {
            
        }
        public static PCubedEzScoreRequest WithDefault(string emailAddress, string idNumber, string phoneNumber)
        {
            return new PCubedEzScoreRequest()
            {
                IdNumber = IdentityNumberRequestField.Get(idNumber),
                EmailAddress = EmailAddressRequestField.Get(emailAddress),
                PhoneNumber = PhoneNumberRequestField.Get(phoneNumber)
            };
        }

        public IAmEmailAddressRequestField EmailAddress { get; private set; }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }

        public IAmPhoneNumberRequestField PhoneNumber { get; private set; }
    }
}
