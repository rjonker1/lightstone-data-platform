using Lace.Domain.Core.Requests.Contracts.RequestFields;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities.Requests
{
    public class LightstonePropertyRequest : IAmLightstonePropertyRequest
    {
        public IAmUserIdRequestField UserId { get; private set; }
        public IAmIdentityNumberRequestField IdentityNumber { get; private set; }
        public IAmTrackingNumberRequestField TrackingNumber { get; private set; }
        public IAmMaxRowsToReturnRequestField MaxRowsToReturn { get; private set; }

        public LightstonePropertyRequest(IAmUserIdRequestField userId, IAmIdentityNumberRequestField identityNumber, IAmTrackingNumberRequestField trackingNumber, IAmMaxRowsToReturnRequestField maxRowsToReturn)
        {
            UserId = userId;
            IdentityNumber = identityNumber;
            TrackingNumber = trackingNumber;
            MaxRowsToReturn = maxRowsToReturn;
        }
    }
}