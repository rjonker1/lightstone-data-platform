using System.Collections;
using System.Collections.Generic;
using Lace.Models.Lightstone;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics
{
    public class BaseRetrievalMetric : IRetrieveValuationFromMetrics
    {
        //private IEnumerable<Statistic> _statistics;
        private readonly IGetStatistics _getStatistics;
        private readonly IGetMetrics _getMetrics;
        private readonly ILaceRequestCarInformation _request;


        public bool IsSatisfied { get; private set; }
        public IRespondWithValuation Valuation { get; private set; }

        public BaseRetrievalMetric(IGetStatistics getStatistics, IGetMetrics getMetrics,
            ILaceRequestCarInformation request, IRespondWithValuation valuation)
        {
            _getStatistics = getStatistics;
            _getMetrics = getMetrics;
            _request = request;
            Valuation = valuation;
        }
        
        public void BuildValuation()
        {
            if (_request.CarId == null || _request.Year == null) return;

            _getStatistics.GetStatistics(_request);

            _getMetrics.GetMetrics(_request);

            Valuation.AddImageGauages(GetImageGaugeMetrics());

        }

        private IEnumerable<IRespondWithImageGaugeModel> GetImageGaugeMetrics()
        {
            return new ImageGaugesMetric(_getStatistics.Statistics, _request, _getMetrics.Metrics).MetricResult;
        }


    }
}
