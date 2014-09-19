using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetStatistics
    {
        IEnumerable<Statistic> Statistics { get; }
        void GetStatistics(IProvideCarInformationForRequest request);
    }
}
