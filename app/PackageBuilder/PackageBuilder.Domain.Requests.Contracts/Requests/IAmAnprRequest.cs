using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmAnprRequest : IAmDataProviderRequest
    {
        IAmImageRequestField Image { get; }
        IAmLatitudeRequestField Latitude { get; }
        IAmLongitudeReqeustField Longitude { get; }
    }
}