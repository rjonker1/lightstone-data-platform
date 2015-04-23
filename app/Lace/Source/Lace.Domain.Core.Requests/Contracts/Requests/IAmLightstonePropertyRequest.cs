using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmLightstonePropertyRequest : IAmDataProviderRequest
    {
        IAmUserIdRequestField UserId { get; }
        IAmIdentityNumberRequestField IdentityNumber { get; }
        IAmTrackingNumberRequestField TrackingNumber { get; }
        IAmMaxRowsToReturnRequestField MaxRowsToReturn { get; }
    }
}