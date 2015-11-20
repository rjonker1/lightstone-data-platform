using Common.Logging;
using Lace.Caching.BuildingBlocks.Handlers;
using Quartz;

namespace Lace.Caching.Manager.Service.Jobs
{
    public class RefreshCache : IJob
    {
        private readonly IHandleClearingData _clear;
        private readonly IHandleRefreshingData _refresh;
        private static readonly ILog Log = LogManager.GetLogger<RefreshCache>();
        public RefreshCache(IHandleClearingData clear, IHandleRefreshingData refresh)
        {
            _clear = clear;
            _refresh = refresh;
        }

        public void Execute(IJobExecutionContext context)
        {
            Log.InfoFormat("Attempting to execute the refresh cache job");
            _clear.Handle();
            _refresh.Handle();
            Log.InfoFormat("Executed the refresh cache job");
        }
    }
}