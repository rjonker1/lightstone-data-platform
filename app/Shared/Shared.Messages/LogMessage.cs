using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Shared.Messages
{
    public class LogMessage : IPublishableMessage
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public LogLevel Level { get; set; }
        public SystemName SystemName { get; set; }

        public LogMessage() { }

        public LogMessage(string message, LogLevel level, SystemName systemName, Exception exception = null)
        {
            Message = message;
            Level = level;
            SystemName = systemName;
            Exception = exception;
        }
    }
}
