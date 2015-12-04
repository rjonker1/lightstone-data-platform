using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class PCubedEzScoreRequest : IAmPCubedEzScoreRequest
    {
        public PCubedEzScoreRequest(ICollection<IAmRequestField> requestFields)
        {
            IdNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            PhoneNumber = requestFields.GetRequestField<IAmPhoneNumberRequestField>();
            EmailAddress = requestFields.GetRequestField<IAmEmailAddressRequestField>();
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmPhoneNumberRequestField PhoneNumber { get; private set; }
        public IAmEmailAddressRequestField EmailAddress { get; private set; }
    }
}
