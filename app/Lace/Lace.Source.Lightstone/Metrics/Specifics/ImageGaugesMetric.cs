using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class ImageGaugesMetric : IHaveMetricForRetrieval
    {
        public IEnumerable<Statistic> Statistics { get; private set; }
        public MetricTypes[] Metrics { get; private set; }
        public ILaceRequestCarInformation Request { get; private set; }

        private const int SubjectBand = 48;
        private const int LowBand = 49;
        private const int HighBand = 50;
        private const int QuarterBand = 51;

        public ImageGaugesMetric(IEnumerable<Statistic> statistics,
            ILaceRequestCarInformation request)
        {
            Statistics = statistics;
            Metrics = new[]
            {
                MetricTypes.MaxSpeed, MetricTypes.Acceleration, MetricTypes.KiloWatts, MetricTypes.Torque,
                MetricTypes.FuelEconomy, MetricTypes.Co2
            };

            Request = request;
        }

        public void GetStatistics()
        {

        }

        private Statistic GetLowStat(int metricId)
        {
            return Statistics
                .FirstOrDefault(w => w.Metric_ID == metricId && w.Band_ID == LowBand);
        }

        private Statistic GetSubjectStat(int metricId)
        {
           // return Statistics.FirstOrDefault(w => w.Metric_ID == metricId && )
            throw new NotImplementedException();
        }

    }
}
