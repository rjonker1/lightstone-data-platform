using System;

namespace Workflow.Bus
{
    public class ExceptionPrettyPrinter
    {
        public string Print(Exception e)
        {
            var message = string.Format("{0}{1}{2}{1}", e.Message, Environment.NewLine, e.StackTrace);
            var currentException = e.InnerException;

            while (currentException != null)
            {
                message += string.Format("{0}{1}{2}{1}", currentException.Message, Environment.NewLine,
                    currentException.StackTrace);

                currentException = currentException.InnerException;
            }

            return message;
        }
    }
}