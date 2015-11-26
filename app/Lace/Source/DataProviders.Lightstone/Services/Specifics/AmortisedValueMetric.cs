using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class AmortisedValueMetric : IRetrieveATypeOfMetric<AmortisedValueModel>
    {
        public List<AmortisedValueModel> MetricResult { get; private set; }
        public IEnumerable<StatisticDto> Statistics { get; private set; }

        private static readonly MetricTypes[] Metrics = {MetricTypes.AmortisedValues};
        private readonly IHaveCarInformation _request;
        private IList<StatisticDto> _statistics;
      //  private readonly IEnumerable<Band> _bands;

        public AmortisedValueMetric(IHaveCarInformation request, IEnumerable<StatisticDto> statistics) //IEnumerable<Band> bands
        {
            Statistics = statistics;
            _request = request;
          //  _bands = bands;
            MetricResult = new List<AmortisedValueModel>();
        }

        public IRetrieveATypeOfMetric<AmortisedValueModel> Get()
        {
            foreach (var metric in Metrics)
            {
                GetStatistic((int) metric);
                AddToMetrics();
            }

            return this;
        }

        private void AddToMetrics()
        {
            foreach (var statistic in _statistics)
            {
                MetricResult.Add(new AmortisedValueModel(statistic.BandName ?? string.Empty,
                    statistic.MoneyValue.HasValue ? statistic.MoneyValue.Value : 0.00M));
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

        private void GetStatistic(int metricId)
        {
            var makeId = GetMakeIdFromStatistics();

            _statistics = makeId == 0
                ? new List<StatisticDto>()
                : Statistics.Where(w => w.MakeId == makeId && w.MetricId == metricId).ToList();
        }

        //private string GetBandName(int bandId)
        //{
        //    if (!_bands.Any()) return string.Empty;

        //    var band = _bands.FirstOrDefault(w => w.Band_ID == bandId);
        //    return band != null ? band.BandName : string.Empty;
        //}
    }
}
