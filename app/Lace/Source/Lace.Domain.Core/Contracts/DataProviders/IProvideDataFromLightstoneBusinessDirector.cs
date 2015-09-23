using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstoneBusinessDirector : IPointToLaceProvider, IProvideCriticalFailure
    {
        IEnumerable<IProvideDirector> Directors { get; }
        IAmLightstoneBusinessDirectorRequest Request { get; }
    }
}