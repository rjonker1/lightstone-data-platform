using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class LighstonePropertyRequest : IAmLightstonePropertyRequest
    {
        public LighstonePropertyRequest(IAmIdentityNumberRequestField identityNumber)
        {
            IdentityNumber = identityNumber;
        }

        public IAmUserIdRequestField UserId { get; private set; }

        public IAmIdentityNumberRequestField IdentityNumber { get; private set; }

        public IAmTrackingNumberRequestField TrackingNumber { get; private set; }

        public IAmMaxRowsToReturnRequestField MaxRowsToReturn { get; private set; }
    }
}
