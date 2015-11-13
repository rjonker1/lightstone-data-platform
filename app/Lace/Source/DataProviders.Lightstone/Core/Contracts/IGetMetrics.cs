using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetMetrics
    {
        IEnumerable<Metric> Metrics { get; }
        void GetMetrics(IHaveCarInformation request);
    }
}
