using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Entities;
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
                .Where(w => w.MetricId == metricId && w.YearId.HasValue && w.YearId.Value == _request.Year)
                .ToList();
        }

        private void AddToMetrics()
        {
            foreach (var gauge in _gauges)
            {
                MetricResult.Add(new RepairIndexModel(gauge.YearId.HasValue ? gauge.YearId.Value : 0,
                    GetBandName(gauge.BandId),
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
