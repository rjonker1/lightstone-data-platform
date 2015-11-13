using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmJisRequest : IAmDataProviderRequest
    {
        IAmCroppedImageRequestField CroppedImage { get; }

        IAmFullImageRequestField FullImage { get; }

        IAmFullImageThumbRequestField FullImageThumb { get; }

        IAmLatitudeRequestField Latitude { get; }

        IAmLongitudeReqeustField Longitude { get; }

        IAmSightingDateRequestField SightingDate { get; }

        IAmSiteLocationRequestField SiteLocation { get; }

        IAmSiteNameRequestField SiteName { get; }

        IAmSessionIdRequestField SessionId { get; }

        IAmRegistrationCodeRequestField UserName { get; }

        IAmLicenceNumberRequestField LicensePlateNumber { get; }
    }
}
