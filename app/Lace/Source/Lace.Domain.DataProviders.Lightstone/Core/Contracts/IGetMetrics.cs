using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetMetrics
    {
        IEnumerable<Metric> Metrics { get; }
        void GetMetrics(IHaveCarInformation request);
    }
}
