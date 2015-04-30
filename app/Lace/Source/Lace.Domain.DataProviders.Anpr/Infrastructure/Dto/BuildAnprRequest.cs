using Lace.Domain.DataProviders.Anpr.AnprServiceReference;
using Lace.Domain.DataProviders.Anpr.Core.Contracts;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure.Dto
{
    public class BuildAnprRequest : IBuildTheRequestForAnpr
    {
        private readonly IAmAnprRequest _request;

        public AnprSubComplexType AnprRequest { get; private set; }

        public BuildAnprRequest(IAmAnprRequest request)
        {
            _request = request;
        }

        public IBuildTheRequestForAnpr Build()
        {
            AnprRequest = new AnprSubComplexType()
            {
                ImagetoAnpr = _request.Image.Field
            };

            return this;
        }
    }
}
