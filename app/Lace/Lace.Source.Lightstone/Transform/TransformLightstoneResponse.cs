using Lace.Models.Lightstone;
using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;

namespace Lace.Source.Lightstone.Transform
{
    public class TransformLightstoneResponse : ITransform
    {
        public bool Continue { get; private set; }
        public IResponseFromLightstone Result { get; private set; }
        private readonly IRetrieveValuationFromMetrics _metricResponse;
        private readonly IRetrieveCarInformation _carInformation;
        private readonly string _vinNumber;

        public TransformLightstoneResponse(IRetrieveValuationFromMetrics metricResponse,
            IRetrieveCarInformation carInformation, string vinNumber)
        {
            Continue = metricResponse != null && metricResponse.IsSatisfied;
            Result = Continue ? new LightstoneResponse() : null;

            _metricResponse = metricResponse;
            _carInformation = carInformation;
            _vinNumber = vinNumber;
        }

        public void Transform()
        {
            Result = new LightstoneResponse(_carInformation.CarInformation.CarId, _carInformation.CarInformation.Year,
                _vinNumber, _carInformation.CarInformation.ImageUrl, _carInformation.CarInformation.Quarter,
                _carInformation.CarInformation.CarFullname, _carInformation.CarInformation.CarModel,
                _metricResponse.Valuation);
        }
    }
}
