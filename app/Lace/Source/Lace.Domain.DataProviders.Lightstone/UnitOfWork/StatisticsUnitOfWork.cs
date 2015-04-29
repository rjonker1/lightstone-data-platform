using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class StatisticsUnitOfWork : IGetStatistics
    {
        private readonly ILog _log;
        private readonly IReadOnlyRepository<Statistic> _repository;

        public IEnumerable<Statistic> Statistics { get; private set; }

        public StatisticsUnitOfWork(IReadOnlyRepository<Statistic> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetStatistics(IHaveCarInformation request)
        {
            try
            {
                Statistics = _repository.Get(SelectStatements.GetStatisticsView,
                    new {request.CarId, request.Year, request.MakeId});
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Statistics data because of {0}", ex.Message);
            }
        }
    }
}
