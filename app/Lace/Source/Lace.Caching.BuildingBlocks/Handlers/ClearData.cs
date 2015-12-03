using Common.Logging;
using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Caching.BuildingBlocks.Handlers
{
    public class ClearData : IHandleClearingData
    {
        private readonly ICacheRepository _repository;
        private static readonly ILog Log = LogManager.GetLogger<ClearData>();

        public ClearData(ICacheRepository repository)
        {
            _repository = repository;
        }

        public void Handle()
        {
            Log.Info("Attempting to clearing all the data from the cache");
            _repository.ClearAll();
            Log.Info("All data in the cache should be cleared");
        }
    }
}