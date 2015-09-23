using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstoneBusinessCompany : IPointToLaceProvider, IProvideCriticalFailure
    {
        IEnumerable<IProvideCompany> Companies { get; }
        IAmLightstoneBusinessCompanyRequest Request { get; }
    }
}