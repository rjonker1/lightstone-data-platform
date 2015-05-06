using Common.Logging;
using Lace.Caching.BuildingBlocks.Handlers;
using Quartz;

namespace Lace.Caching.Manager.Service.Jobs
{
    public class RefreshCache : IJob
    {
        private readonly IHandleClearingData _clear;
        private readonly IHandleRefreshingData _refresh;
        private readonly ILog _log;
        public RefreshCache(IHandleClearingData clear, IHandleRefreshingData refresh)
        {
            _clear = clear;
            _refresh = refresh;
            _log = LogManager.GetLogger(GetType());
        }

        public void Execute(IJobExecutionContext context)
        {
            _log.InfoFormat("Attempting to execute the refresh cache job");
        }
    }
}
