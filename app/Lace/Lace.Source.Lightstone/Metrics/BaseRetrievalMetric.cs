using System.Collections.Generic;
using Lace.Models.Lightstone;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Metrics.Specifics;

namespace Lace.Source.Lightstone.Metrics
{
    public class BaseRetrievalMetric : IRetrieveValuationFromMetrics
    {
        private readonly IGetStatistics _getStatistics;
        private readonly IGetMetrics _getMetrics;
        private readonly ILaceRequestCarInformation _request;
        private readonly IGetBands _getBands;



        public bool IsSatisfied { get; private set; }
        public IRespondWithValuation Valuation { get; private set; }

        public BaseRetrievalMetric(IGetStatistics getStatistics, IGetMetrics getMetrics,
            ILaceRequestCarInformation request, IRespondWithValuation valuation, IGetBands getBands)
        {
            _getStatistics = getStatistics;
            _getMetrics = getMetrics;
            _getBands = getBands;
            _request = request;
            Valuation = valuation;
        }

        public void BuildValuation()
        {
            if (_request.CarId == null || _request.Year == null) return;

            _getStatistics.GetStatistics(_request);
            _getMetrics.GetMetrics(_request);
            _getBands.GetBands(_request);

            Valuation.AddImageGauages(GetImageGaugeMetrics());
            Valuation.AddAccidentDistribution(GetAccidentDistributionMetrics());

        }

        private IEnumerable<IRespondWithAccidentDistributionModel> GetAccidentDistributionMetrics()
        {
            return
                new AccidentDistributionMetric(_getStatistics.Statistics, _getBands.Bands).MetricResult;
        }

        private IEnumerable<IRespondWithImageGaugeModel> GetImageGaugeMetrics()
        {
            return new ImageGaugesMetric(_getStatistics.Statistics, _getMetrics.Metrics).MetricResult;
        }
    }
}
