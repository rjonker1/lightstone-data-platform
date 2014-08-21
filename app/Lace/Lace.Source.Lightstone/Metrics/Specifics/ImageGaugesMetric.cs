using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone.Dto;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class ImageGaugesMetric : IRetrieveATypeOfMetric<ImageGaugeModel>
    {
        public List<ImageGaugeModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private readonly IEnumerable<Metric> _metricsData;
        private readonly MetricTypes[] _metrics;
        private readonly ILaceRequestCarInformation _request;

        private IList<Statistic> _gauges;

        private const int SubjectBand = 48;
        private const int LowBand = 49;
        private const int HighBand = 50;
        private const int QuarterBand = 51;

        public ImageGaugesMetric(IEnumerable<Statistic> statistics,
            ILaceRequestCarInformation request, IEnumerable<Metric> metricData)
        {
            Statistics = statistics;
            _metricsData = metricData;
            _metrics = new[]
            {
                MetricTypes.MaxSpeed, MetricTypes.Acceleration, MetricTypes.KiloWatts, MetricTypes.Torque,
                MetricTypes.FuelEconomy, MetricTypes.Co2
            };

            _request = request;
            MetricResult = new List<ImageGaugeModel>();
        }

        public void Get()
        {
            foreach (var metric in _metrics)
            {
                _gauges.Clear();
                _gauges = GetGauges((int) metric);
                var lowStat = GetLowStat();
                var subjectStat = GetSubjectStat();
                var maxStat = GetMaxStat();
                var quarterStat = GetQuarterStat();

                if (lowStat == null || subjectStat == null || maxStat == null || quarterStat == null) continue;

                if (
                    !(lowStat.FloatValue.HasValue && subjectStat.FloatValue.HasValue && maxStat.FloatValue.HasValue &&
                      quarterStat.FloatValue.HasValue)) continue;

                MetricResult.Add(new ImageGaugeModel(lowStat.FloatValue, maxStat.FloatValue, subjectStat.FloatValue,
                    quarterStat.FloatValue, GetGaugeName()));

            }

        }

        private IList<Statistic> GetGauges(int metricId)
        {
            return Statistics
                .Where(w => w.Metric_ID == metricId)
                .ToList();
        }

        private Statistic GetLowStat()
        {
            return _gauges
                .FirstOrDefault(w => w.Band_ID == LowBand);
        }

        private Statistic GetSubjectStat()
        {
            return _gauges
                .FirstOrDefault(w => w.Band_ID == SubjectBand);
        }

        private Statistic GetMaxStat()
        {
            return _gauges
                .FirstOrDefault(w => w.Band_ID == HighBand);
        }

        private Statistic GetQuarterStat()
        {
            return _gauges
                .FirstOrDefault(w => w.Band_ID == QuarterBand);
        }

        private string GetGaugeName()
        {
            return _gauges.FirstOrDefault() != null
                ? _metricsData.FirstOrDefault(w => w.Metric_ID == _gauges.FirstOrDefault().Metric_ID).MetricName
                : string.Empty;
        }
    }
}
