using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Commands;
using Lim.Schedule.Core;
using Quartz;

namespace Lim.Schedule.Integrations.Daily.Api
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
            _log.Info("Fetching Daily Pull API Integrations");
            _fetch.Handle(new FetchConfigurationCommand(IntegrationAction.Pull, IntegrationType.Api,Frequency.Daily));

            if (!_fetch.Configurations.Any())
            {
                _log.Info("There are no daily Pull API Integrations to execute");
                return;
            }

            _log.InfoFormat("Executing {0} Daily Pull Integrations", _fetch.Configurations.Count());
            _execute.Handle(new ExecuteApiPullConfigurationCommand());
        }
    }
}