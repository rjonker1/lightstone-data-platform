using System;
using Lace.Domain.DataProviders.Jis.Core.Contracts;
using Lace.Domain.DataProviders.Jis.Infrastructure.Images;
using Lace.Domain.DataProviders.Jis.JisServiceReference;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Jis.Infrastructure.Dto
{
    public class BuildJisRequest : IBuildRequestForJis
    {
        public DataStoreRequest JisRequest { get; private set; }
        private readonly IAmJisRequest _request;

        public BuildJisRequest(IAmJisRequest request)
        {
            _request = request;
        }

        public IBuildRequestForJis Build()
        {
            JisRequest = new DataStoreRequest()
            {
                VehicleSightingRequest = new VehicleSightingRequest()
                {
                    ClientHasImages = true,
                    CroppedImage = Convert.FromBase64String(_request.CroppedImage.Field),
                    FullImage = new Base64Image(_request.FullImageThumb.Field).BinaryImage,
                    FullImageIsThumb = true,
                    Latitude = _getLatitudeCoordinate(_request.Latitude),
                    Longitude = _getLongitudeCoordinate(_request.Longitude)
                },
                DataStoresToQuery = new[] {"UniCode"},
                VehicleRegNoToQuery = _request.LicensePlateNumber.Field
            };
            return this;
        }

        private readonly Func<IAmRequestField, double> _getLatitudeCoordinate =
            (field) =>
            {
                var coordinate = GetValidLatitudeCoordinate(field);

                return double.Parse(string.Format("{0}{1}", Math.Truncate(coordinate),
                    (Math.Abs(coordinate%1)*60).ToString("00.0000000000")));
            };

        private readonly Func<IAmRequestField, double> _getLongitudeCoordinate =
            (field) =>
            {
                var coordinate = GetValidLongitudeCoordinate(field);

                return double.Parse(string.Format("{0}{1}", Math.Truncate(coordinate),
                    (Math.Abs(coordinate%1)*60).ToString("00.0000000000")));
            };

        private static double GetValidLatitudeCoordinate(IAmRequestField coordinate)
        {
            if (coordinate == null || string.IsNullOrEmpty(coordinate.Field))
                return 0;

            double latitude;

            double.TryParse(coordinate.Field, out latitude);

            return 90 >= latitude && latitude >= -90 ? latitude : 0;

        }

        private static double GetValidLongitudeCoordinate(IAmRequestField coordinate)
        {
            if (coordinate == null || string.IsNullOrEmpty(coordinate.Field))
                return 0;

            double longitude;

            double.TryParse(coordinate.Field, out longitude);

            return 180 >= longitude && longitude >= -180 ? longitude : 0;

        }
    }
}