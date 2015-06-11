using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneBusinessResponse
    {
        public Lace.Domain.Core.Entities.LightstoneBusinessCompanyResponse LightstoneCompanyResponse()
        {
            var result = new List<IProvideCompany>()
            {
                new CompanyResponse(0,"","","","","","","","","","","","","","","","")};

            return new LightstoneBusinessCompanyResponse(result);
        } 
    }
}