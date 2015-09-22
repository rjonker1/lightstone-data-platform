using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class BmwFinanceResponse
    {
        public Lace.Domain.Core.Entities.BmwFinanceResponse EmptyBmwFinanceResponse()
        {
            return new Lace.Domain.Core.Entities.BmwFinanceResponse(new List<IRespondWithBmwFinance>()
            {
                new BmwFinanceRecord("",0.0M,DateTime.MinValue, DateTime.MinValue, "","","","",0,"","")
            });
        }
    }
}
