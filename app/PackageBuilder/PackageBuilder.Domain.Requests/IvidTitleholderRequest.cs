using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests.RequestsPB;

namespace PackageBuilder.Domain.Requests
{
    public class IvidTitleholderRequest : IAmIvidTitleholderRequestPB
    {
        public IAmRequesterNameRequestField RequesterName { get; private set; }
        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }
        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }

        public IvidTitleholderRequest(IAmVinNumberRequestField vinNumber)
        {
            VinNumber = vinNumber;
        }
    }
}