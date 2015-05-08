using System.Collections.Generic;
using Common.Logging;
using Lace.Shared.DataProvider.Contracts;
using Lace.Shared.DataProvider.Models;

namespace Lace.Caching.BuildingBlocks.Handlers
{
    public class RefreshData : IHandleRefreshingData
    {
        private readonly ICacheRepository _repository;
        private readonly ILog _log;

        public RefreshData(ICacheRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle()
        {
            _log.Info("Adding Items to the Cache");
            ItemsToCache.ForEach( f => f.AddToCache(_repository));
            _log.InfoFormat("{0} Items should have been added to the Cache", ItemsToCache.Count);
        }

        private static readonly List<IAmCachable> ItemsToCache = new List<IAmCachable>()
        {
            //new Band(),
            //new CarSpecification(),
            //new Make(),
            //new Metric(),
            //new Municipality(),
           new Sale(),
           // new Statistic(),
           // new CarInformation()
        };
    }
}
