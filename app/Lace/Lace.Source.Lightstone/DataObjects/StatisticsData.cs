using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Source.Lightstone.Repository.Infrastructure;

namespace Lace.Source.Lightstone.DataObjects
{
    public class StatisticsData : IHaveTheStatisticsRepository, IGetStatistics
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public IReadOnlyRepository<Statistics> Repository { private get; set; }
        public IEnumerable<Statistics> Statistics { get; private set; }

        public void GetStatistics(ILaceRequestCarInformation request)
        {
            try
            {
                Repository = new StatisticsRepository(ConnectionFactory.ForAutoCarStatsDatabase(), CacheConnectionFactory.LocalClient());
                Statistics = Repository.FindAllWithRequest(request);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Statistics data because of {0}", ex.Message);
            }
        }
    }
}
