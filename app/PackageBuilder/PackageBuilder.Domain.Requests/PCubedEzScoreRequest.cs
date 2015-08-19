using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class PCubedEzScoreRequest : IAmPCubedEzScoreRequest 
    {
        public PCubedEzScoreRequest(IAmIdentityNumberRequestField idNumber, IAmPhoneNumberRequestField phoneNumber,
           IAmEmailAddressRequestField emailAddress)
        {
            IdNumber = idNumber;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmPhoneNumberRequestField PhoneNumber { get; private set; }
        public IAmEmailAddressRequestField EmailAddress { get; private set; }
    }
}
