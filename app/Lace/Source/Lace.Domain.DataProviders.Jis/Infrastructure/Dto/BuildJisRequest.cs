using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Jis.Core.Contracts;
using Lace.Domain.DataProviders.Jis.Infrastructure.Images;
using Lace.Domain.DataProviders.Jis.JisServiceReference;

namespace Lace.Domain.DataProviders.Jis.Infrastructure.Dto
{
    public class BuildJisRequest //: IBuildRequestForJis
    {
        //TODO: Uncomment after updating packagebuilder request contracts nugets
        public DataStoreRequest JisRequest { get; private set; }
        //private readonly IHaveJisInformation _request;

        //public BuildJisRequest(IHaveJisInformation request)
        //{
        //    _request = request;
        //}

        //public IBuildRequestForJis Build()
        //{
        //    JisRequest = new DataStoreRequest()
        //    {
        //        VehicleSightingRequest = new VehicleSightingRequest()
        //        {
        //            ClientHasImages = true,
        //            CroppedImage = Convert.FromBase64String(_request.CroppedImage),
        //            FullImage = new Base64Image(_request.FullImageThumb).BinaryImage,
        //            FullImageIsThumb = true,
        //            Latitude = _getCoordinate(_request.Latitude),
        //            Longitude = _getCoordinate(_request.Longitude)
        //        },
        //        DataStoresToQuery = new[] {"UniCode"},
        //        VehicleRegNoToQuery = _request.LicensePlateNumber
        //    };
        //    return this;
        //}

        private readonly Func<double, double> _getCoordinate =
            (coordinate) =>
                double.Parse(string.Format("{0}{1}", Math.Truncate(coordinate),
                    (Math.Abs(coordinate%1)*60).ToString("00.0000000000")));
    }
}
