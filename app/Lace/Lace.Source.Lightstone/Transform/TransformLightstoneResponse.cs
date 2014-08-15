using Lace.Models.Lightstone;
using Lace.Models.Lightstone.Dto;


namespace Lace.Source.Lightstone.Transform
{
    public class TransformLightstoneResponse : ITransform
    {
        public bool Continue { get; private set; }
        public LightstoneResponse Result { get; private set; }
        private readonly IHaveBaseLevelMetrics _response;

        public TransformLightstoneResponse(IHaveBaseLevelMetrics response)
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
