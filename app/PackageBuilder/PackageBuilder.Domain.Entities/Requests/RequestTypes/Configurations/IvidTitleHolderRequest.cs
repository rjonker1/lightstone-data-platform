using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using PackageBuilder.Domain.Requests.Fields;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class IvidTitleHolderRequest : IAmIvidTitleholderRequest
    {
        public IvidTitleHolderRequest(ICollection<IAmRequestField> requestFields, IHaveUser user, string contactNumber)
        {
            RequesterName = new RequesterNameRequestField(user.UserFirstName);
            RequesterEmail = new RequesterEmailRequestField(user.UserName);
            RequesterPhone = new RequesterPhoneRequestField(contactNumber);
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
        }

        public IAmRequesterNameRequestField RequesterName { get; private set; }
        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }
        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}