using Lace.Models.Lightstone;
using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Metrics;


namespace Lace.Source.Lightstone.Transform
{
    public class TransformLightstoneResponse : ITransform
    {
        public bool Continue { get; private set; }
        public LightstoneResponse Result { get; private set; }
        private readonly IHaveAllTheMetrics _response;

        public TransformLightstoneResponse(IHaveAllTheMetrics response)
        {
            Continue = response != null;
            Result = Continue ? new LightstoneResponse() : null;
            _response = response;
        }
        
        public void Transform()
        {
            Result = new LightstoneResponse();
        }
    }
}
