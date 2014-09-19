using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetMetrics
    {
        IEnumerable<Metric> Metrics { get; }
        void GetMetrics(IProvideCarInformationForRequest request);
    }
}
