using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;


namespace Lace.Source.Lightstone.Transform
{
    public class TransformLightstoneResponse : ITransform
    {
        public bool Continue { get; private set; }
        public LightstoneResponse Result { get; private set; }
        private readonly IRetrieveValuationFromMetrics _metricResponse;
        private readonly IRetrieveCarDetailFromCarVendorInformation _carDetailResponse;
        private readonly IRetrieveCarInformation _carInformation;

        public TransformLightstoneResponse(IRetrieveValuationFromMetrics metricResponse,
            IRetrieveCarDetailFromCarVendorInformation carDetailReponse, IRetrieveCarInformation carInformation)
        {
            Continue = metricResponse != null && metricResponse.IsSatisfied;
            Result = Continue ? new LightstoneResponse() : null;

            _metricResponse = metricResponse;
            _carDetailResponse = carDetailReponse;
            _carInformation = carInformation;
        }

        public void Transform()
        {
            Result = new LightstoneResponse();
        }
    }
}
