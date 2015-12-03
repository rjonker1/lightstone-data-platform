using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Caching;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;

namespace Lace.Caching.BuildingBlocks.Handlers
{
    public class RefreshData : IHandleRefreshingData
    {
        private readonly ICacheRepository _repository;
        private static readonly ILog Log = LogManager.GetLogger<RefreshData>();

        public RefreshData(ICacheRepository repository)
        {
            _repository = repository;
        }

        public void Handle()
        {
            Log.Info("Adding Items to the Cache");
            ItemsToCache.ForEach(f => f.AddToCache(_repository));
            Log.InfoFormat("{0} Items should have been added to the Cache", ItemsToCache.Count);
        }

        private static readonly List<IAmCachable> ItemsToCache = new List<IAmCachable>()
        {
            new CarSpecification(),
           // new Sale(),
            new CarInformationDto()
        };
    }
}
