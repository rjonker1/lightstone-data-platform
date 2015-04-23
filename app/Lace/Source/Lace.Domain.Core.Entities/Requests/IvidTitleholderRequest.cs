using Lace.Domain.Core.Requests.Contracts.RequestFields;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities.Requests
{
    public class IvidTitleholderRequest : IAmIvidTitleholderRequest
    {
        public IAmRequesterNameRequestField RequesterName { get; private set; }
        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }
        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }

        public IvidTitleholderRequest(IAmRequesterNameRequestField requesterName, IAmRequesterPhoneRequestField requesterPhone, IAmRequesterEmailRequestField requesterEmail, IAmVinNumberRequestField vinNumber)
        {
            RequesterName = requesterName;
            RequesterPhone = requesterPhone;
            RequesterEmail = requesterEmail;
            VinNumber = vinNumber;
        }
    }
}