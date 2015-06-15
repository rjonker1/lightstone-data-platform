using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneDirectorResponse
    {
        public LightstoneBusinessDirectorResponse LightstoneCompanyResponse()
        {
            var result = new List<IProvideDirector>()
            {
                new DirectorResponse(0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, "", 0, "",
                    "", "", "", "", "", "", 0, 0)
            };

            return new LightstoneBusinessDirectorResponse(result);
        }
    }
}