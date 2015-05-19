﻿using Common.Logging;
using Quartz;

namespace Lim.Schedule.Integrations.Custom.Api
{
    public class PullJob : IJob
    {
        private readonly ILog _log;

        public PullJob()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public void Execute(IJobExecutionContext context)
        {
            _log.InfoFormat("Executing the Api Custom Integration");
        }
    }
}