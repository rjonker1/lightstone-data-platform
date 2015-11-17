using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Quartz;

namespace Lim.Schedule.Service.Jobs.Integrations.EveryMinute.Api
{
    public class PushJob : IJob
    {
        private static readonly ILog Log = LogManager.GetLogger<PushJob>();
        private readonly IHandleFetchingApiPushConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _execute;

        public PushJob(IHandleFetchingApiPushConfiguration handler, IHandleExecutingApiConfiguration execute)
        {
            _fetch = handler;
            _execute = execute;
        }

        public void Execute(IJobExecutionContext context)
        {
            Log.Info("Fetching Every Minute Push API Integrations");
            _fetch.Handle(new FetchConfigurationCommand(IntegrationAction.Push, IntegrationType.Api,Frequency.EveryMinute));

            if (_fetch.Configurations == null || !_fetch.Configurations.Any())
            {
                Log.Info("There are no Every Minute Push API Integrations to execute");
                return;
            }

            Log.InfoFormat("Executing {0} Daily Every Minute API Integrations", _fetch.Configurations.Count());
            _execute.Handle(new ExecuteApiPushConfigurationCommand(_fetch.Configurations));
        }
    }
}
