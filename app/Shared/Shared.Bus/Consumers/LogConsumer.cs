using Common.Logging;
using DataPlatform.Shared.Messaging;
using Shared.Messages;
using LogLevel = DataPlatform.Shared.Enums.LogLevel;

namespace Shared.Bus.Consumers
{
    public class LogConsumer : AbstractMessageHandler<LogMessage>
    {
        public override void Handle(LogMessage message)
        {
            // Set logfile name and application name variables
            log4net.GlobalContext.Properties["LogName"] = message.SystemName;
            log4net.GlobalContext.Properties["ApplicationName"] = GetType().Assembly.GetName().Name;

            // Load log4net configuration
            var logfile = new System.IO.FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(logfile);

            var log = LogManager.GetLogger(message.LoggerType);

            if (message.Level == LogLevel.Debug)
                log.Debug(message.Message);
            if (message.Level == LogLevel.Info)
                log.Info(message.Message);
            if (message.Level == LogLevel.Warn)
                log.Warn(message.Message);
            if (message.Level == LogLevel.Error)
                log.Error(message.Message, message.Exception);
            if (message.Level == LogLevel.Fatal)
                log.Fatal(message.Message);
        }
    }
}