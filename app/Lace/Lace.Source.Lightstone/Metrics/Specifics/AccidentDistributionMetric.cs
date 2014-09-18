﻿using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone.DataObject;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class AccidentDistributionMetric : IRetrieveATypeOfMetric<AccidentDistributionModel>
    {
        public List<AccidentDistributionModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = {MetricTypes.AccidentDistribution};
        private IList<Statistic> _gauges;
        private readonly IEnumerable<Band> _bands; 

        public AccidentDistributionMetric(IEnumerable<Statistic> statistics, IEnumerable<Band> bands)
        {
            _bands = bands;
            Statistics = statistics;
           MetricResult = new List<AccidentDistributionModel>();
        }

        public IRetrieveATypeOfMetric<AccidentDistributionModel> Get()
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
                .Where(w => w.Metric_ID == metricId)
                .ToList();
        }

        private void AddToMetrics()
        {
            foreach (var gauge in _gauges)
            {
                MetricResult.Add(new AccidentDistributionModel(GetBandName(gauge.Band_ID), gauge.FloatValue.HasValue ? gauge.FloatValue.Value : 0.00));
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
