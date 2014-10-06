using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
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
