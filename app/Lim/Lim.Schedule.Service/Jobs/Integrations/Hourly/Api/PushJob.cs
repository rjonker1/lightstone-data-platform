using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Quartz;

namespace Lim.Schedule.Service.Jobs.Integrations.Hourly.Api
{
    public class PushJob : IJob
    {
        private readonly ILog _log;
        private readonly IHandleFetchingApiPushConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _execute;

        public PushJob(IHandleFetchingApiPushConfiguration handler, IHandleExecutingApiConfiguration execute)
        {
            _log = LogManager.GetLogger(GetType());
            _fetch = handler;
            _execute = execute;
        }

        public void Execute(IJobExecutionContext context)
        {
            _log.Info("Fetching Hourly Push API Integrations");
            _fetch.Handle(new FetchConfigurationCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.Hourly));

            if (!_fetch.Configurations.Any())
            {
                _log.Info("There are no Hourly Push API Integrations to execute");
                return;
            }

            _log.InfoFormat("Executing {0} Hourly Push API Integrations", _fetch.Configurations.Count());
            _execute.Handle(new ExecuteApiPushConfigurationCommand(_fetch.Configurations));
        }
    }
}