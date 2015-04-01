using System;
namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IHaveJisInformation
    {
        string CroppedImage { get; }

        string FullImage { get; }

        string FullImageThumb { get; }

        double Latitude { get; }

        double Longitude { get; }

        DateTime SightingDate { get; }

        string SiteLocation { get; }

        string SiteName { get; }

        int SessionId { get; }

        string UserName { get; }

        string LicensePlateNumber { get; }
    }
}
