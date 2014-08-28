using System;
using System.Collections.Generic;
using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class TotalSalesByAgeMetric : IRetrieveATypeOfMetric<TotalSalesByAgeModel>
    {
        public List<TotalSalesByAgeModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}
