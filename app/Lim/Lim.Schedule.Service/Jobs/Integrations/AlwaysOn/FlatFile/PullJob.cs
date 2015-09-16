using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Quartz;

namespace Lim.Schedule.Service.Jobs.Integrations.AlwaysOn.FlatFile
{
    public class PullJob : IJob
    {
        private static readonly ILog Log = LogManager.GetLogger<PullJob>();
        private readonly IHandleFetchingFlatFilePullConfiguration _fetch;
        private readonly IHandleExecutingFlatFileConfiguration _execute;

        public PullJob(IHandleFetchingFlatFilePullConfiguration fetch, IHandleExecutingFlatFileConfiguration execute)
        {
            _fetch = fetch;
            _execute = execute;
        }

        public void Execute(IJobExecutionContext context)
        {
            Log.InfoFormat("Executing the Flat File Always On Integration");
            _fetch.Handle(new FetchConfigurationForAlwaysOnCommand(IntegrationAction.Pull, IntegrationType.FlatFile, Frequency.AlwaysOn));

            if (!_fetch.Configurations.Any())
            {
                Log.Info("There are no always on flat file pull integrations to execute");
                return;
            }

            Log.InfoFormat("Executing {0} Alwyas On Flat File Integrations", _fetch.Configurations.Count());
            _execute.Handle(new ExecuteFlatFilePullConfigurationCommand(_fetch.Configurations));
        }
    }
}