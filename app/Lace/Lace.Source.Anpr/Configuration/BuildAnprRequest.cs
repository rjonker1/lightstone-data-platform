using Lace.Request;
using Lace.Source.Anpr.AnprWebService;

namespace Lace.Source.Anpr.Configuration
{
    public class BuildAnprRequest : IBuildTheRequestForAnpr
    {
        private readonly ILaceRequest _request;

        public AnprSubComplexType AnprRequest { get; private set; }

        public BuildAnprRequest(ILaceRequest request)
        {
            _request = request;
        }

        public IBuildTheRequestForAnpr Build()
        {
            AnprRequest = new AnprSubComplexType()
            {
                ImagetoAnpr = _request.CoOrdinates.Image
            };

            return this;
        }
    }

}
