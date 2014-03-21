using System;
using Common.Logging;
using EasyNetQ;

namespace Workflow.Billing.Consumer
{
    public class RabbitMQLogger : IEasyNetQLogger
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public void DebugWrite(string format, params object[] args)
        {
            log.DebugFormat(format, args);
        }

        public void InfoWrite(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }

        public void ErrorWrite(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }

        public void ErrorWrite(Exception exception)
        {
            log.ErrorFormat("RabbitMQ failure:", exception);
        }
    }
}
