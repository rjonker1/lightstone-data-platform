using Common.Logging;
using Quartz;

namespace Lim.Schedule.Hourly.Api
{
    public class Job : IJob
    {
        private readonly ILog _log;

        public Job()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public void Execute(IJobExecutionContext context)
        {
            _log.InfoFormat("Executing the Api Hourly Integration");
        }
    }
}
