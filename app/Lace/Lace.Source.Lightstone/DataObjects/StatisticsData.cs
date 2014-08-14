using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Source.Lightstone.Repository.Infrastructure;

namespace Lace.Source.Lightstone.DataObjects
{
    public class StatisticsData : IHaveStatisticsRepository, IGetStatistics
    {
        public IReadOnlyRepository<Statistics> Repository { private get; set; }
        public IEnumerable<Statistics> Statistics { get; private set; }
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public void GetStatistics(IHaveLightstoneRequest request)
        {
            try
            {
                Repository = new StatisticsRepository(ConnectionFactory.ForAutoCarStatsDatabase(),
                    MemoryConnectionFactory.LocalClient());
                Statistics = Repository.FindAllWithRequest(request);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Statistics data fbecause of {0}", ex.Message);
            }
        }
    }
}
