using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromBmwFinance : IPointToLaceProvider
    {
        IAmBmwFinanceRequest Request { get; }
        IEnumerable<IRespondWithBmwFinance> Finances { get; }
    }
}
