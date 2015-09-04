using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Finance;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class BmwFinanceResponse
    {
        public Lace.Domain.Core.Entities.BmwFinanceResponse EmptyBmwFinanceResponse()
        {
            return new Lace.Domain.Core.Entities.BmwFinanceResponse(new List<IRespondWithBmwFinance>());
        }
    }
}
