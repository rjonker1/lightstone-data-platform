using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstoneBusinessDirector : IPointToLaceProvider
    {
        IEnumerable<IProvideDataFromLightstoneBusinessDirector> Directors { get; }
    }
}