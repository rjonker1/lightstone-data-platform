using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetMetrics
    {
        IEnumerable<Metric> Metrics { get; }
        void GetMetrics(IHaveCarInformation request);
    }
}
