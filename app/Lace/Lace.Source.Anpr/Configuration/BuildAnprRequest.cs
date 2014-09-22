using Lace.Request;

namespace Lace.Source.Anpr.Configuration
{
    public class BuildAnprRequest
    {
        private readonly ILaceRequest _request;

       // public AnprSubComplexType AnprRequest { get; private set; }

        public BuildAnprRequest(ILaceRequest request)
        {
            _request = request;
        }

        public void Build()
        {
            //AnprRequest = new AnprSubComplexType()
            //{
            //    ImagetoAnpr = _request.CoOrdinates.Image
            //};
        }
    }
}
