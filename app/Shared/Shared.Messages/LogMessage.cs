using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Shared.Messages
{
    public class LogMessage : IPublishableMessage
    {
        public string LoggerType { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public LogLevel Level { get; set; }
        public SystemName SystemName { get; set; }

        public LogMessage() { }

        public LogMessage(string loggerType, string message, LogLevel level, SystemName systemName, string exception = null)
        {
            LoggerType = loggerType;
            Message = message;
            Level = level;
            SystemName = systemName;
            Exception = exception;
        }
    }
}
