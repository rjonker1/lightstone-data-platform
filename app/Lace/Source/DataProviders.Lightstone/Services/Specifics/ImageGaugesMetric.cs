using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class ImageGaugesMetric : IRetrieveATypeOfMetric<ImageGaugeModel>
    {
        public List<ImageGaugeModel> MetricResult { get; private set; }
        public IEnumerable<StatisticDto> Statistics { get; private set; }

        private readonly IEnumerable<Metric> _metricsData;

        private static readonly MetricTypes[] Metrics =
        {
            MetricTypes.MaxSpeed, MetricTypes.Acceleration, MetricTypes.KiloWatts, MetricTypes.Torque,
            MetricTypes.FuelEconomy, MetricTypes.Co2
        };

        private IList<StatisticDto> _gauges;

        private const int SubjectBand = 48;
        private const int LowBand = 49;
        private const int HighBand = 50;
        private const int QuarterBand = 51;

        public ImageGaugesMetric(IEnumerable<StatisticDto> statistics, IEnumerable<Metric> metricData)
        {
            Statistics = statistics;
            _metricsData = metricData;
            MetricResult = new List<ImageGaugeModel>();
        }

        public IRetrieveATypeOfMetric<ImageGaugeModel> Get()
        {
            foreach (var metric in Metrics)
            {
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

            return this;

        }

        private IList<StatisticDto> GetGauges(int metricId)
        {
            return Statistics
                .Where(w => w.MetricId == metricId)
                .ToList();
        }

        private StatisticDto GetLowStat()
        {
            return _gauges
                .FirstOrDefault(w => w.BandId == LowBand);
        }

        private StatisticDto GetSubjectStat()
        {
            return _gauges
                .FirstOrDefault(w => w.BandId == SubjectBand);
        }

        private StatisticDto GetMaxStat()
        {
            return _gauges
                .FirstOrDefault(w => w.BandId == HighBand);
        }

        private StatisticDto GetQuarterStat()
        {
            return _gauges
                .FirstOrDefault(w => w.BandId == QuarterBand);
        }

        private string GetGaugeName()
        {
            return _gauges.FirstOrDefault() != null
                ? _metricsData.FirstOrDefault(w => w.Metric_ID == _gauges.FirstOrDefault().MetricId).MetricName
                : string.Empty;
        }
    }
}
