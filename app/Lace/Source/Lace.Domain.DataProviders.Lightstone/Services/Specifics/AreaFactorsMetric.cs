using System.Collections.Generic;
using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class AreaFactorsMetric : IRetrieveATypeOfMetric<AreaFactorModel>
    {
        public List<AreaFactorModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = { MetricTypes.AreaFactors };
        private IList<Statistic> _gauges;
        private readonly IEnumerable<Municipality> _municipalities;

        public AreaFactorsMetric(IEnumerable<Statistic> statistics, IEnumerable<Municipality> municipalities)
        {
            _municipalities = municipalities;
            Statistics = statistics;
            MetricResult = new List<AreaFactorModel>();
        }

        public IRetrieveATypeOfMetric<AreaFactorModel> Get()
        {
            foreach (var metric in Metrics)
            {
                GetGauges((int)metric);
                AddToMetrics();
            }
            return this;
        }

        private void GetGauges(int metricId)
        {
            _gauges = Statistics
                .Where(w => w.Metric_ID == metricId)
                .ToList();
        }

        private void AddToMetrics()
        {
            foreach (var gauge in _gauges)
            {
                MetricResult.Add(new AreaFactorModel(GetMuncipalityName(gauge.Municipality_ID), gauge.FloatValue.HasValue ? gauge.FloatValue.Value : 0.00));
            }
        }

        private string GetMuncipalityName(int? municipalityId)
        {
            if (!_municipalities.Any()) return string.Empty;

            var municipality = _municipalities.FirstOrDefault(w => w.Municipality_ID == municipalityId);
            return municipality != null ? municipality.MunicipalityName : string.Empty;
        }
    }
}
