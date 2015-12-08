using System;
using System.Configuration;
using DataPlatform.Shared.Enums;
using Shared.Messages;
using Workflow.Publisher;

namespace Shared.Logging
{
    public interface IDataPlatformLogger
    {
        void Debug(Type loggerType, string message);
        void Debug(string loggerType, string message);

        void Info(Type loggerType, string message);
        void Info(string loggerType, string message);

        void Warn(Type loggerType, string message);
        void Warn(string loggerType, string message);

        void Error(Type loggerType, string message);
        void Error(string loggerType, string message);
        void Error(Type loggerType, string message, Exception exception);
        void Error(string loggerType, string message, Exception exception);

        void Fatal(Type loggerType, string message);
        void Fatal(string loggerType, string message);
        void Fatal(Type loggerType, string message, Exception exception);
        void Fatal(string loggerType, string message, Exception exception);
    }

    public class DataPlatformLogger : IDataPlatformLogger
    {
        private readonly IWorkflowPublisher _publisher;
        private readonly SystemName _systemName = SystemName.Api;

        public DataPlatformLogger(IWorkflowPublisher publisher)
        {
            _publisher = publisher;
            var systemNameSetting = ConfigurationManager.AppSettings["tokenizer/logging/systemName/enum"];
            if (!string.IsNullOrEmpty(systemNameSetting))
                Enum.TryParse(systemNameSetting, out _systemName);
        }

        private void Log(string loggerType, string message, LogLevel level, SystemName systemName, Exception exception = null)
        {
            _publisher.Publish(new LogMessage(loggerType, message, level, systemName, exception));
        }

        public void Debug(Type loggerType, string message)
        {
            Log(loggerType.FullName, message, LogLevel.Debug, _systemName);
        }

        public void Debug(string loggerType, string message)
        {
            Log(loggerType, message, LogLevel.Debug, _systemName);
        }

        public void Info(Type loggerType, string message)
        {
            Log(loggerType.FullName, message, LogLevel.Info, _systemName);
        }

        public void Info(string loggerType, string message)
        {
            Log(loggerType, message, LogLevel.Info, _systemName);
        }

        public void Warn(Type loggerType, string message)
        {
            Log(loggerType.FullName, message, LogLevel.Warn, _systemName);
        }

        public void Warn(string loggerType, string message)
        {
            Log(loggerType, message, LogLevel.Warn, _systemName);
        }

        public void Error(Type loggerType, string message)
        {
            Log(loggerType.FullName, message, LogLevel.Error, _systemName);
        }

        public void Error(string loggerType, string message)
        {
            Log(loggerType, message, LogLevel.Error, _systemName);
        }

        public void Error(Type loggerType, string message, Exception exception)
        {
            Log(loggerType.FullName, message, LogLevel.Error, _systemName, exception);
        }

        public void Error(string loggerType, string message, Exception exception)
        {
            Log(loggerType, message, LogLevel.Error, _systemName, exception);
        }

        public void Fatal(Type loggerType, string message)
        {
            Log(loggerType.FullName, message, LogLevel.Fatal, _systemName);
        }

        public void Fatal(string loggerType, string message)
        {
            Log(loggerType, message, LogLevel.Fatal, _systemName);
        }

        public void Fatal(Type loggerType, string message, Exception exception)
        {
            Log(loggerType.FullName, message, LogLevel.Fatal, _systemName, exception);
        }

        public void Fatal(string loggerType, string message, Exception exception)
        {
            Log(loggerType, message, LogLevel.Fatal, _systemName, exception);
        }
    }
}