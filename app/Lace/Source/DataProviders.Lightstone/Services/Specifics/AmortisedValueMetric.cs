using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class AmortisedValueMetric : IRetrieveATypeOfMetric<AmortisedValueModel>
    {
        public List<AmortisedValueModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = {MetricTypes.AmortisedValues};
        private readonly IHaveCarInformation _request;
        private IList<Statistic> _gauges;
        private readonly IEnumerable<Band> _bands;

        public AmortisedValueMetric(IHaveCarInformation request, IEnumerable<Statistic> statistics,
            IEnumerable<Band> bands)
        {
            Statistics = statistics;
            _request = request;
            _bands = bands;
            MetricResult = new List<AmortisedValueModel>();
        }

        public IRetrieveATypeOfMetric<AmortisedValueModel> Get()
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
            foreach (var gauge in _gauges)
            {
                MetricResult.Add(new AmortisedValueModel(GetBandName(gauge.BandId),
                    gauge.MoneyValue.HasValue ? gauge.MoneyValue.Value : 0.00M));
            }
        }


        private int GetMakeIdFromStatistics()
        {
            if (!_request.HasValidCarIdAndYear()) return 0;

            var statisic =
                Statistics.FirstOrDefault(w => w.CarId == _request.CarId && w.YearId == _request.Year);

            if (statisic == null) return 0;

            return statisic.MakeId ?? 0;
        }

        private void GetGauges(int metricId)
        {
            var makeId = GetMakeIdFromStatistics();

            _gauges = makeId == 0
                ? new List<Statistic>()
                : Statistics.Where(w => w.MakeId == makeId && w.MetricId == metricId).ToList();
        }

        private string GetBandName(int bandId)
        {
            if (!_bands.Any()) return string.Empty;

            var band = _bands.FirstOrDefault(w => w.Band_ID == bandId);
            return band != null ? band.BandName : string.Empty;
        }
    }
}
