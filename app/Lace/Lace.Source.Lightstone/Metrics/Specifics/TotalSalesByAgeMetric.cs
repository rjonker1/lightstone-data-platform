using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone.Dto;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class TotalSalesByAgeMetric : IRetrieveATypeOfMetric<TotalSalesByAgeModel>
    {
        public List<TotalSalesByAgeModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = { MetricTypes.TotalSalesByAge };
        private readonly IEnumerable<Band> _bands;
        private readonly IEnumerable<CarType> _carTypes;
        private readonly ILaceRequestCarInformation _request;

        private IList<Statistic> _gauges;

        public TotalSalesByAgeMetric(ILaceRequestCarInformation request, IEnumerable<Statistic> statistics, IEnumerable<Band> bands,
            IEnumerable<CarType> carTypes)
        {
            Statistics = statistics;
            _carTypes = carTypes;
            _bands = bands;
            _request = request;

        }

        public void Get()
        {
            foreach (var metric in Metrics)
            {
                GetGauges((int)metric);
                AddToMetrics();
            }
        }

        private void AddToMetrics()
        {
            //foreach (var gauge in _gauges)
            //{
            // var values = _gauges.Select(s => new Pair<string, double>(GetCarTypeName(s.CarType_ID), ))

            var salesByAge = _gauges.Select(s => new
            {
                Band = GetBandName(s.Band_ID),
                CarType = GetCarTypeName(s.CarType_ID),
                Value = (s.FloatValue.HasValue ? s.FloatValue.Value : 0)
            });

            // }
        }


        private void GetGauges(int metricId)
        {
            var makeId = GetMakeIdFromStatistics();

            _gauges = makeId == 0
                ? new List<Statistic>()
                : Statistics.Where(w => w.Make_ID == makeId && w.Metric_ID == metricId).ToList();
        }

        private int GetMakeIdFromStatistics()
        {
            if (!_request.CarId.HasValue || !_request.Year.HasValue) return 0;

            var statisic =
                Statistics.FirstOrDefault(w => w.Car_ID == _request.CarId && w.Year_ID == _request.Year);

            if (statisic == null) return 0;

            return statisic.Make_ID ?? 0;
        }


        private string GetCarTypeName(int? carTypeId)
        {
            if (!_carTypes.Any()) return string.Empty;

            var carType = _carTypes.FirstOrDefault(w => w.CarType_ID == carTypeId);
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
