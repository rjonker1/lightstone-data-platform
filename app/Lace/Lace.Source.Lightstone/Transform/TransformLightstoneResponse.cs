using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Metrics;


namespace Lace.Source.Lightstone.Transform
{
    public class TransformLightstoneResponse : ITransform
    {
        public bool Continue { get; private set; }
        public LightstoneResponse Result { get; private set; }
        private readonly IRetrieveValuationFromMetrics _metricResponse;

        public TransformLightstoneResponse(IRetrieveValuationFromMetrics metricResponse)
        {
            Continue = metricResponse != null && metricResponse.IsSatisfied;
            Result = Continue ? new LightstoneResponse() : null;
            _metricResponse = metricResponse;
        }

        public void Transform()
        {
            Result = new LightstoneResponse();
        }
    }
}
