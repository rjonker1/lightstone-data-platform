using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Source.Lightstone.Repository.ForModel;
using Lace.Source.Lightstone.Repository.Infrastructure;

namespace Lace.Source.Lightstone.DataObjects
{
    public class MetricData : IGetMetrics
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Metric> Metrics { get; private set; }
        public IReadOnlyRepository<Metric> Repository { private get; set; }

        public void GetMetrics(ILaceRequestCarInformation request)
        {
            try
            {
                Repository = new MetricRepository(ConnectionFactory.ForAutoCarStatsDatabase(),
                    CacheConnectionFactory.LocalClient());
                Metrics = Repository.GetAll();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Metric data because of {0}", ex.Message);
            }
        }
    }
}
