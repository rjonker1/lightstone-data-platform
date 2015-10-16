using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneBusinessResponse
    {
        public Lace.Domain.Core.Entities.LightstoneBusinessCompanyResponse Default()
        {
            var result = new List<IProvideCompany>()
            {
                new CompanyResponse(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
                    .SetCompanyDetail(0, 0, 0, 0, "", "", "", "", false, "", "", "")
                    .SetPhysicalAddress("", "", "", "", "", "", "", "")
                    .SetPostalAddress("", "", "", "", "")
            };

            var response = new LightstoneBusinessCompanyResponse(result);
            response.AddResponseState(DataProviderResponseState.NoRecords);
            return response;
        }
    }
}