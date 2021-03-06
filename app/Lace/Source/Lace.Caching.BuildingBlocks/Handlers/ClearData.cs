﻿using Common.Logging;
using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Caching.BuildingBlocks.Handlers
{
    public class ClearData : IHandleClearingData
    {
        private readonly ICacheRepository _repository;
        private readonly ILog _log;
        public ClearData(ICacheRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }
        public void Handle()
        {
            _log.Info("Attempting to clearing all the data from the cache");
            _repository.ClearAll();
            _log.Info("All data in the cache should be cleared");
        }
    }
}
