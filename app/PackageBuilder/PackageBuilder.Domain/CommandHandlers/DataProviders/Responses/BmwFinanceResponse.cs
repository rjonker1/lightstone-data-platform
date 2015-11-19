using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class BmwFinanceResponse
    {
        public Lace.Domain.Core.Entities.BmwFinanceResponse Default()
        {
            var result = new Lace.Domain.Core.Entities.BmwFinanceResponse(new List<IRespondWithBmwFinance>()
            {
                new BmwFinanceRecord("","",DateTime.MinValue, DateTime.MinValue, "","","","",0,"","","","")
            });
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}
