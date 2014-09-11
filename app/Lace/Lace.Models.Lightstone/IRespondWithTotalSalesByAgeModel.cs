using System.Collections.Generic;
using Lace.Models.Lightstone.Dto.Metric;

namespace Lace.Models.Lightstone
{
    public interface IRespondWithTotalSalesByAgeModel
    {
        string Band { get; }
        List<Pair<string, double>> Values { get; }
    }
}