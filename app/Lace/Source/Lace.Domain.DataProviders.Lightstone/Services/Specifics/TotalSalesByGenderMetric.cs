using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class TotalSalesByGenderMetric : IRetrieveATypeOfMetric<TotalSalesByGenderModel>
    {
        public List<TotalSalesByGenderModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = { MetricTypes.TotalSalesByGender };
        private readonly IEnumerable<Band> _bands;
        private readonly IHaveCarInformation _request;

        private IList<Statistic> _gauges;

        public TotalSalesByGenderMetric(IHaveCarInformation request, IEnumerable<Statistic> statistics,
            IEnumerable<Band> bands)
        {
            Statistics = statistics;
            _bands = bands;
            _request = request;
            MetricResult = new List<TotalSalesByGenderModel>();
        }

        public IRetrieveATypeOfMetric<TotalSalesByGenderModel> Get()
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
            var result =
                _gauges.Select(
                    s =>
                        new TotalSalesByGenderModel(GetCarTypeName(s.CarTypeId), GetBandName(s.BandId),
                            s.FloatValue.HasValue ? s.FloatValue.Value : 0));

            MetricResult.AddRange(result);
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
