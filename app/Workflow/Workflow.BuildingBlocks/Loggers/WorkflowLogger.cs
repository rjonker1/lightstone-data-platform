using System;
using System.Linq;
using Common.Logging;
using EasyNetQ;

namespace Workflow.BuildingBlocks.Loggers
{
    public class WorkflowLogger : IEasyNetQLogger
    {
        private static readonly ILog Log = LogManager.GetLogger<WorkflowLogger>();

        public void DebugWrite(string format, params object[] args)
        {
            if (!args.Any())
                Log.Debug(format);
            else
                Log.DebugFormat(format, args);
        }

        public void InfoWrite(string format, params object[] args)
        {
            if (!args.Any())
                Log.Info(format);
            else
                Log.InfoFormat(format, args);
        }

        public void ErrorWrite(string format, params object[] args)
        {
            if (!args.Any())
                Log.Error(format);
            else
                Log.ErrorFormat(format, args);
        }

        public void ErrorWrite(Exception exception)
        {
            var message = string.Format("{0}{1}{2}{1}", exception.Message, Environment.NewLine, exception.StackTrace);
            var currentException = exception.InnerException;

            while (currentException != null)
            {
                message += string.Format("{0}{1}{2}{1}", currentException.Message, Environment.NewLine, currentException.StackTrace);

                currentException = currentException.InnerException;
            }

            Log.Error(message);
        }
    }
}