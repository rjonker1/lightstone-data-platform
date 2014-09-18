using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone.DataObject;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class AmortisedValueMetric : IRetrieveATypeOfMetric<AmortisedValueModel>
    {
        public List<AmortisedValueModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = {MetricTypes.AmortisedValues};
        private readonly ILaceRequestCarInformation _request;
        private IList<Statistic> _gauges;
        private readonly IEnumerable<Band> _bands;

        public AmortisedValueMetric(ILaceRequestCarInformation request, IEnumerable<Statistic> statistics,
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
                MetricResult.Add(new AmortisedValueModel(GetBandName(gauge.Band_ID),
                    gauge.MoneyValue.HasValue ? gauge.MoneyValue.Value : 0.00M));
            }
        }


        private int GetMakeIdFromStatistics()
        {
            if (!_request.CarId.HasValue || !_request.Year.HasValue) return 0;

            var statisic =
                Statistics.FirstOrDefault(w => w.Car_ID == _request.CarId && w.Year_ID == _request.Year);

            if (statisic == null) return 0;

            return statisic.Make_ID ?? 0;
        }

        private void GetGauges(int metricId)
        {
            var makeId = GetMakeIdFromStatistics();

            _gauges = makeId == 0
                ? new List<Statistic>()
                : Statistics.Where(w => w.Make_ID == makeId && w.Metric_ID == metricId).ToList();
        }

        private string GetBandName(int bandId)
        {
            if (!_bands.Any()) return string.Empty;

            var band = _bands.FirstOrDefault(w => w.Band_ID == bandId);
            return band != null ? band.BandName : string.Empty;
        }
    }
}
