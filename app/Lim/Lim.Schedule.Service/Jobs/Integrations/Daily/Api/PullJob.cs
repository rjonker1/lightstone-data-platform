using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Quartz;

namespace Lim.Schedule.Service.Jobs.Integrations.Daily.Api
{
    public class PullJob : IJob
    {
        private static readonly ILog Log = LogManager.GetLogger<PullJob>();
        private readonly IHandleFetchingApiPullConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _execute;

        public PullJob(IHandleFetchingApiPullConfiguration fetch, IHandleExecutingApiConfiguration execute)
        {
            _fetch = fetch;
            _execute = execute;
        }

        public void Execute(IJobExecutionContext context)
        {
            Log.Info("Fetching Daily Pull API Integrations");
            _fetch.Handle(new FetchConfigurationCommand(IntegrationAction.Pull, IntegrationType.Api, Frequency.Daily));

            if (!_fetch.Configurations.Any())
            {
                Log.Info("There are no daily Pull API Integrations to execute");
                return;
            }

            Log.InfoFormat("Executing {0} Daily Pull Integrations", _fetch.Configurations.Count());
            _execute.Handle(new ExecuteApiPullConfigurationCommand(_fetch.Configurations));
        }
    }
}