using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmLightstonePropertyRequest : IAmDataProviderRequest
    {
        IAmUserIdRequestField UserId { get; }
        IAmIdentityNumberRequestField IdentityNumber { get; }
        IAmTrackingNumberRequestField TrackingNumber { get; }
        IAmMaxRowsToReturnRequestField MaxRowsToReturn { get; }
    }
}