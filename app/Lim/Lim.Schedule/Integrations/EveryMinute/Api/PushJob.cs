using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Commands;
using Lim.Schedule.Core;
using Quartz;

namespace Lim.Schedule.Integrations.EveryMinute.Api
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
            _log.Info("Fetching Every Minute Push API Integrations");
            _fetch.Handle(new FetchConfigurationCommand(IntegrationAction.Push, IntegrationType.Api,Frequency.EveryMinute));

            if (_fetch.Configurations == null || !_fetch.Configurations.Any())
            {
                _log.Info("There are no Every Minute Push API Integrations to execute");
                return;
            }

            _log.InfoFormat("Executing {0} Daily Every Minute API Integrations", _fetch.Configurations.Count());
            _execute.Handle(new ExecuteApiPushConfigurationCommand(_fetch.Configurations));
        }
    }
}
