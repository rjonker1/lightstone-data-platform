using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class MetricUnitOfWork : IGetMetrics
    {
        private readonly ILog _log;
        public IEnumerable<Metric> Metrics { get; private set; }
        private readonly IReadOnlyRepository<Metric> _repository;

        public MetricUnitOfWork(IReadOnlyRepository<Metric> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetMetrics(IHaveCarInformation request)
        {
            try
            {
                Metrics = _repository.GetAll();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Metric data because of {0}", ex.Message);
            }
        }
    }
}
