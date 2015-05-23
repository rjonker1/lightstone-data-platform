using System;
using System.Linq;
using Common.Logging;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Quartz;

namespace Lim.Schedule.Service.Jobs.Integrations.Custom.Api
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
            _log.Info("Fetching Daily Push API Integrations");
            _fetch.Handle(new FetchConfigurationForCustomCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.Custom,
                DateTime.Now.ToString("dddd")));

            if (!_fetch.Configurations.Any())
            {
                _log.Info("There are no Custom Push API Integrations to execute");
                return;
            }

            _log.InfoFormat("Executing {0} Custom Push API Integrations on {1}", _fetch.Configurations.Count(), DateTime.Now.ToString("dddd"));
            _execute.Handle(new ExecuteApiPushConfigurationCommand(_fetch.Configurations));
        }
    }
}