﻿using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneDirectorResponse
    {
        public LightstoneBusinessDirectorResponse Default()
        {
            var result = new List<IProvideDirector>()
            {
                new DirectorResponse(0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, "", 0, "",
                    "", "", "", "", "", "", 0, 0)
                    .SetBusinessAddress("","","","","")
                    .SetPostalAddress("","","","","")
                    .SetRegisteredAddress("","","","","")
                    .SetResidentialAddress("","","","","")
            };
            
            var response =  new LightstoneBusinessDirectorResponse(result);
            response.AddResponseState(DataProviderResponseState.NoRecords);
            return response;
        }
    }
}