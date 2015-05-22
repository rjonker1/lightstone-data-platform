using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Business;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneBusinessResponse
    {
        private static Lace.Domain.Core.Entities.LightstoneBusinessResponse DefaultLightstoneBusinessResponse()
        {

            var result = new List<IRespondWithBusiness>(); // List<ReturnCompaniesResponse.Company>();l

            return new Lace.Domain.Core.Entities.LightstoneBusinessResponse(result)
            {
                // TODO: new up a company response
            };
        } 
    }
}