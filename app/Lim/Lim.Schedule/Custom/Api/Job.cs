using Common.Logging;
using Quartz;

namespace Lim.Schedule.Custom.Api
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
            _log.InfoFormat("Executing the Api Custom Integration");
        }
    }
}
