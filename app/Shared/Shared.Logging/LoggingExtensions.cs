using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Common.Logging;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using Microsoft.Practices.ServiceLocation;
using Shared.Messages;
using Workflow.Publisher;

namespace Shared.Logging
{
    public static class LoggingExtensions
    {
        private static readonly IDataPlatformLogger Logger = ServiceLocator.Current.GetInstance<IDataPlatformLogger>();

        private static bool LogToBus()
        {
            var logToBus = true;
            var logToBusSetting = ConfigurationManager.AppSettings["shared/logging/logToBus"];
            if (!string.IsNullOrEmpty(logToBusSetting))
                bool.TryParse(logToBusSetting, out logToBus);

            return Logger != null && logToBus;
        }

        #region .: Enabled Checks :.

        public static bool IsDebugEnabled(this object o)
        {
            return IsDebugEnabled(o.GetType());
        }

        public static bool IsDebugEnabled(this Type t)
        {
            return IsDebugEnabled(t.FullName);
        }

        public static bool IsDebugEnabled(string name)
        {
            return LogManager.GetLogger(name).IsDebugEnabled;
        }

        public static bool IsInfoEnabled(this object o)
        {
            return IsInfoEnabled(o.GetType());
        }

        public static bool IsInfoEnabled(this Type t)
        {
            return IsInfoEnabled(t.FullName);
        }

        public static bool IsInfoEnabled(string name)
        {
            return LogManager.GetLogger(name).IsInfoEnabled;
        }

        public static bool IsWarnEnabled(this object o)
        {
            return IsWarnEnabled(o.GetType());
        }

        public static bool IsWarnEnabled(this Type t)
        {
            return IsWarnEnabled(t.FullName);
        }

        public static bool IsWarnEnabled(string name)
        {
            return LogManager.GetLogger(name).IsWarnEnabled;
        }

        public static bool IsErrorEnabled(this object o)
        {
            return IsErrorEnabled(o.GetType());
        }

        public static bool IsErrorEnabled(this Type t)
        {
            return IsErrorEnabled(t.FullName);
        }

        public static bool IsErrorEnabled(string name)
        {
            return LogManager.GetLogger(name).IsErrorEnabled;
        }

        public static bool IsFatalEnabled(this object o)
        {
            return IsFatalEnabled(o.GetType());
        }

        public static bool IsFatalEnabled(this Type t)
        {
            return IsFatalEnabled(t.FullName);
        }

        public static bool IsFatalEnabled(string name)
        {
            return LogManager.GetLogger(name).IsFatalEnabled;
        }

        #endregion

        /// <summary>
        /// Provides functionality to time a specific section of code, and write the timings to the log file
        /// </summary>
        /// <param name="o">Context on which to log this</param>
        /// <param name="message">Message to display related to the timing code</param>
        /// <returns></returns>
        public static ITimerLogger TimedInfo(this object o, string message)
        {
            var loggerName = "PerformanceTiming." + o.GetType().FullName;
            var logger = LogManager.GetLogger(loggerName);
            if (logger.IsInfoEnabled)
                return new TimerLogger(message, loggerName);
            else return new NullTimerLogger();
        }

        #region .: Debug :.

        public static void Debug(this object o, Func<object> message)
        {
            o.GetType().Debug(message);
        }

        public static void Debug(this Type t, Func<object> message)
        {
            Debug(t.FullName, message);
        }

        public static void Debug(string name, Func<object> message)
        {
            if (LogToBus())
                LogManager.GetLogger(name).Debug(message());
            else
                Logger.Debug(name, message().ToString());
        }

        #endregion

        #region .: Info :.

        public static void Info(this object o, Func<object> message)
        {
            Info(o.GetType(), message);
        }

        public static void Info(this Type t, Func<object> message)
        {
            Info(t.FullName, message);
        }

        public static void Info(string name, Func<object> message)
        {
            if (LogToBus())
                LogManager.GetLogger(name).Info(message());
            else
                Logger.Info(name, message().ToString());
        }
        #endregion

        #region .: Warn :.

        public static void Warn(this object o, Func<object> message)
        {
            Warn(o.GetType(), message);
        }

        public static void Warn(this Type t, Func<object> message)
        {
            Warn(t.FullName, message);
        }

        public static void Warn(string name, Func<object> message)
        {
            if (LogToBus())
                LogManager.GetLogger(name).Warn(message());
            else
                Logger.Warn(name, message().ToString());
        }
        #endregion

        #region .: Error :.

        public static void Error(this object o, Func<object> message, Exception exception)
        {
            Error(o.GetType(), message, exception);
        }

        public static void Error(this object o, Func<object> message)
        {
            Error(o.GetType(), message);
        }

        public static void Error(this Type t, Func<object> message, Exception exception)
        {
            Error(t.FullName, message, exception);
        }

        public static void Error(this Type t, Func<object> message)
        {
            Error(t.FullName, message);
        }

        public static void Error(string name, Func<object> message)
        {
            Error(name, message, null);
        }

        public static void Error(string name, Func<object> message, Exception exception)
        {
            if (LogToBus())
                LogManager.GetLogger(name).Error(message(), exception);
            else
                Logger.Error(name, message().ToString(), exception);
        }

        #endregion

        #region .: Fatal :.

        public static void Fatal(this object o, Func<object> message)
        {
            Fatal(o.GetType(), message);
        }

        public static void Fatal(this Type t, Func<object> message)
        {
            Fatal(t.FullName, message);
        }

        public static void Fatal(string name, Func<object> message)
        {
            if (LogToBus())
                LogManager.GetLogger(name).Fatal(message());
            else
                Logger.Fatal(name, message().ToString());
        }

        #endregion
    }

    public interface ITimerLogger : IDisposable
    {
        double ElapsedTime();
    }


    public class NullTimerLogger : ITimerLogger
    {
        public void Dispose()
        {

        }

        public double ElapsedTime()
        {
            return 0;
        }
    }

    public class TimerLogger : ITimerLogger
    {
        private readonly string _loggerName;
        private readonly object _context;
        private readonly Stopwatch _stopWatch;
        private string _msg = "";

        private TimerLogger(string msg)
        {
            _msg = msg;
            _stopWatch = new Stopwatch();
        }

        private void Init()
        {
            Debug(() => "Starting timer: {0}".FormatWith(_msg));
            _stopWatch.Start();
        }

        public TimerLogger(string msg, object context)
            : this(msg)
        {
            _context = context;
            Init();
        }

        public TimerLogger(string msg, string loggerName)
            : this(msg)
        {
            _loggerName = loggerName;
            Init();
        }



        public double ElapsedTime()
        {
            return _stopWatch.Elapsed.TotalMilliseconds;
        }

        public void Dispose()
        {
            _stopWatch.Stop();
            var ellapsed = _stopWatch.Elapsed.TotalMilliseconds;
            string highlight = GetHighlightString(ellapsed);
            Log(() => "Timer finished in {0}ms{1} - {2}".FormatWith(ellapsed, highlight, _msg));
        }

        /// <summary>
        /// Returns a string used to highlight log messages based on elapsed time
        /// </summary>
        /// <param name="ellapsed"></param>
        /// <returns></returns>
        private string GetHighlightString(double ellapsed)
        {
            var highlight = "";
            if (ellapsed > 1000)
                highlight = "*";
            if (ellapsed > 5000)
                highlight = "**";
            if (ellapsed > 10000)
                highlight = "***";
            return highlight;
        }

        private void Log(Func<object> message)
        {
            if (_loggerName != null)
            {
                LoggingExtensions.Info(_loggerName, message);
            }
            else
            {
                LoggingExtensions.Info(_context, message);
            }
        }

        private void Debug(Func<object> message)
        {
            if (_loggerName != null)
            {
                LoggingExtensions.Debug(_loggerName, message);
            }
            else
            {
                LoggingExtensions.Debug(_context, message);
            }
        }
    }
}