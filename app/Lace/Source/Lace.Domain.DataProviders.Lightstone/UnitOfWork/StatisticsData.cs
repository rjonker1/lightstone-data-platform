using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
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

        public void GetStatistics(IProvideCarInformationForRequest request)
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
