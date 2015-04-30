using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class TotalSalesByAgeMetric : IRetrieveATypeOfMetric<TotalSalesByAgeModel>
    {
        public List<TotalSalesByAgeModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = {MetricTypes.TotalSalesByAge};
        private readonly IEnumerable<Band> _bands;
        private readonly IHaveCarInformation _request;

        private IList<Statistic> _gauges;

        public TotalSalesByAgeMetric(IHaveCarInformation request, IEnumerable<Statistic> statistics,
            IEnumerable<Band> bands)
        {
            Statistics = statistics;
            _bands = bands;
            _request = request;
            MetricResult = new List<TotalSalesByAgeModel>();
        }

        public IRetrieveATypeOfMetric<TotalSalesByAgeModel> Get()
        {
            foreach (var metric in Metrics)
            {
                GetGauges((int) metric);
                AddToMetrics();
            }
            return this;
        }

        private void AddToMetrics()
        {
            if (!_gauges.Any())
                return;

            var salesByAge = _gauges.Select(s => new
            {
                Band = GetBandName(s.BandId),
                CarType = GetCarTypeName(s.CarTypeId),
                Value = (s.FloatValue.HasValue ? s.FloatValue.Value : 0)
            }).GroupBy(g => g.Band, g => g, (key, g) => new
            {
                Band = g.FirstOrDefault(),
                Values = g.Select(c => new Pair<string, double>(c.CarType, c.Value)).ToArray()

            }).ToList();

            if (!salesByAge.Any())
                return;

            MetricResult.AddRange(salesByAge.Select(s => new TotalSalesByAgeModel(s.Values, s.Band.Band)));
        }


        private void GetGauges(int metricId)
        {
            var makeId = GetMakeIdFromStatistics();

            _gauges = makeId == 0
                ? new List<Statistic>()
                : Statistics.Where(w => w.MakeId == makeId && w.MetricId == metricId).ToList();
        }

        private int GetMakeIdFromStatistics()
        {
            if (!_request.HasValidCarIdAndYear()) return 0;

            var statisic =
                Statistics.FirstOrDefault(w => w.CarId == _request.CarId && w.YearId == _request.Year);

            if (statisic == null) return 0;

            return statisic.MakeId ?? 0;
        }


        private string GetCarTypeName(int? carTypeId)
        {
            var carType = Statistics.FirstOrDefault(w => w.CarTypeId == carTypeId);
            return carType != null ? carType.CarTypeName : string.Empty;
        }

        private string GetBandName(int bandId)
        {
            if (!_bands.Any()) return string.Empty;

            var band = _bands.FirstOrDefault(w => w.Band_ID == bandId);
            return band != null ? band.BandName : string.Empty;
        }
    }
}
