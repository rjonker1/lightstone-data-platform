using Lace.Request;
using Lace.Source.Anpr.AnprWebService;

namespace Lace.Source.Anpr.Configuration
{
    public class BuildAnprRequest
    {
        private readonly ILaceRequest _request;

        public AnprSubComplexType AnprRequest { get; set; }

        public BuildAnprRequest(ILaceRequest request)
        {
            _request = request;
        }

        public BuildAnprRequest Build()
        {
            AnprRequest = new AnprSubComplexType()
            {
                ImagetoAnpr = _request.CoOrdinates.Image
            };

            return this;
        }
    }
}
