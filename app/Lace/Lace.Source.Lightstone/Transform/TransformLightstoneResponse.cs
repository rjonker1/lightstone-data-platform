using Lace.Models.Lightstone.DataObject;
using Lace.Models.Responses.Sources;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;

namespace Lace.Source.Lightstone.Transform
{
    public class TransformLightstoneResponse : ITransform
    {
        public bool Continue { get; private set; }
        public IProvideDataFromLightstone Result { get; private set; }
        private readonly IRetrieveValuationFromMetrics _metricResponse;
        private readonly IRetrieveCarInformation _carInformation;


        public TransformLightstoneResponse(IRetrieveValuationFromMetrics metricResponse,
            IRetrieveCarInformation carInformation)
        {
            Continue = metricResponse != null && metricResponse.IsSatisfied;
            Result = Continue ? new LightstoneResponse() : null;

            _metricResponse = metricResponse;
            _carInformation = carInformation;
        }

        public void Transform()
        {
            Result = new LightstoneResponse(_carInformation.CarInformation.CarId, _carInformation.CarInformation.Year,
                _carInformation.CarInformationRequest.Vin, _carInformation.CarInformation.ImageUrl,
                _carInformation.CarInformation.Quarter,
                _carInformation.CarInformation.CarFullname, _carInformation.CarInformation.CarModel,
                _metricResponse.Valuation);
        }
    }
}
