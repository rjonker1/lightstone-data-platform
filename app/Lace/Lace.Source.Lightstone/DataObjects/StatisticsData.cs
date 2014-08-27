using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
{
    public class StatisticsData : IGetStatistics
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IReadOnlyRepository<Statistic> _repository;

        public IEnumerable<Statistic> Statistics { get; private set; }

        public StatisticsData(IReadOnlyRepository<Statistic> repository)
        {
            _repository = repository;
        }

        public void GetStatistics(ILaceRequestCarInformation request)
        {
            try
            {
                Statistics = _repository.FindAllWithRequest(request);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Statistics data because of {0}", ex.Message);
            }
        }
    }
}
