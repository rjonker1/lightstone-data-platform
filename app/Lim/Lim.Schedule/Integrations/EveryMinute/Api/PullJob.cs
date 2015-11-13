using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Quartz;

namespace Lim.Schedule.Integrations.EveryMinute.Api
{
    public class PullJob : IJob
    {
        private readonly ILog _log;
        private readonly IHandleFetchingApiPullConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _execute;

        public PullJob(IHandleFetchingApiPullConfiguration fetch, IHandleExecutingApiConfiguration execute)
        {
            _log = LogManager.GetLogger(GetType());
            _fetch = fetch;
            _execute = execute;
        }

        public void Execute(IJobExecutionContext context)
        {
            _log.Info("Fetching Every Minute Pull API Integrations");
            _fetch.Handle(new FetchConfigurationCommand(IntegrationAction.Pull, IntegrationType.Api,Frequency.EveryMinute));

            if (_fetch.Configurations == null || !_fetch.Configurations.Any())
            {
                _log.Info("There are no Every Minute Pull API Integrations to execute");
                return;
            }

            _log.InfoFormat("Executing {0} Every Minute Pull Integrations", _fetch.Configurations.Count());
            _execute.Handle(new ExecuteApiPullConfigurationCommand());
        }
    }
}
