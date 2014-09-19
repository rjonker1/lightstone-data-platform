using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
{
    public class MetricData : IGetMetrics
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Metric> Metrics { get; private set; }
        private readonly IReadOnlyRepository<Metric> _repository;

        public MetricData(IReadOnlyRepository<Metric> repository)
        {
            _repository = repository;
        }

        public void GetMetrics(IProvideCarInformationForRequest request)
        {
            try
            {
                Metrics = _repository.GetAll();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Metric data because of {0}", ex.Message);
            }
        }
    }
}
