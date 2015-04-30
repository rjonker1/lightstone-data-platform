using System;
using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class LighstonePropertyRequest : IAmLightstonePropertyRequest
    {
        private LighstonePropertyRequest()
        {
            
        }

        public static IAmLightstonePropertyRequest WithDefault(long identitynumber, int maxRowsToReturn, Guid trackingNumber,
            Guid userId)
        {
            return new LighstonePropertyRequest()
            {
                IdentityNumber = IdentityNumberRequestField.Get(Convert.ToString(identitynumber)),
                MaxRowsToReturn = MaxRowsToReturnRequestField.Get(Convert.ToString(maxRowsToReturn)),
                TrackingNumber = TrackingNumberRequestField.Get(Convert.ToString(trackingNumber)),
                UserId = UserIdRequestField.Get(Convert.ToString(userId))
            };
        }


        public IAmIdentityNumberRequestField IdentityNumber { get; private set; }

        public IAmMaxRowsToReturnRequestField MaxRowsToReturn { get; private set; }

        public IAmTrackingNumberRequestField TrackingNumber { get; private set; }

        public IAmUserIdRequestField UserId { get; private set; }
    }
}
