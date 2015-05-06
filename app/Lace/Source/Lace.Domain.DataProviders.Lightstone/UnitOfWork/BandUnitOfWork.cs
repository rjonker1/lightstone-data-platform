using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class BandUnitOfWork : IGetBands
    {
        private readonly ILog _log;
        public IEnumerable<Band> Bands { get; private set; }
        private readonly IReadOnlyRepository<Band> _repository;

        public BandUnitOfWork(IReadOnlyRepository<Band> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetBands(IHaveCarInformation request)
        {
            try
            {
                Bands = _repository.GetAll(Band.SelectAll,Band.CacheAllKey);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Band data because of {0}", ex, ex.Message);
            }
        }
    }
}
