using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone.DataObject;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class AuctionFactorsMetric : IRetrieveATypeOfMetric<AuctionFactorModel>
    {
        public List<AuctionFactorModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = {MetricTypes.AuctionFactors};
        private readonly ILaceRequestCarInformation _request;
        private IList<Statistic> _gauges;
        private readonly IEnumerable<Make> _makes;

        public AuctionFactorsMetric(ILaceRequestCarInformation request, IEnumerable<Statistic> statistics,
            IEnumerable<Make> makes)
        {
            _makes = makes;
            _request = request;
            Statistics = statistics;
            MetricResult = new List<AuctionFactorModel>();
        }

        public IRetrieveATypeOfMetric<AuctionFactorModel> Get()
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
                MetricResult.Add(new AuctionFactorModel(GetMakeName(gauge.Make_ID),
                    gauge.FloatValue.HasValue ? (decimal) gauge.FloatValue.Value : 0.0M));
            }
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

        private string GetMakeName(int? makeId)
        {
            if (!_makes.Any()) return string.Empty;

            var make = _makes.FirstOrDefault(w => w.Make_ID == makeId);
            return make != null ? make.MakeName : string.Empty;
        }
    }
}
