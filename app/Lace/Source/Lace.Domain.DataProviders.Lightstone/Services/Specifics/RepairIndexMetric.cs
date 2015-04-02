using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class RepairIndexMetric : IRetrieveATypeOfMetric<RepairIndexModel>
    {
        public List<RepairIndexModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = {MetricTypes.RepairIndex};
        private IList<Statistic> _gauges;
        private readonly IEnumerable<Band> _bands;
        private readonly IHaveCarInformation _request;

        public RepairIndexMetric(IHaveCarInformation request, IEnumerable<Statistic> statistics,
            IEnumerable<Band> bands)
        {
            _bands = bands;
            _request = request;
            Statistics = statistics;
            MetricResult = new List<RepairIndexModel>();
        }


        public IRetrieveATypeOfMetric<RepairIndexModel> Get()
        {
            foreach (var metric in Metrics)
            {
                GetGauges((int) metric);
                AddToMetrics();
            }

            return this;
        }

        private void GetGauges(int metricId)
        {
            _gauges = Statistics
                .Where(w => w.Metric_ID == metricId && w.Year_ID.HasValue && w.Year_ID.Value == _request.Year)
                .ToList();
        }

        private void AddToMetrics()
        {
            foreach (var gauge in _gauges)
            {
                MetricResult.Add(new RepairIndexModel(gauge.Year_ID.HasValue ? gauge.Year_ID.Value : 0,
                    GetBandName(gauge.Band_ID),
                    gauge.FloatValue.HasValue ? gauge.FloatValue.Value : 0.00));
            }
        }

        private string GetBandName(int bandId)
        {
            if (!_bands.Any()) return string.Empty;

            var band = _bands.FirstOrDefault(w => w.Band_ID == bandId);
            return band != null ? band.BandName : string.Empty;
        }
    }
}
