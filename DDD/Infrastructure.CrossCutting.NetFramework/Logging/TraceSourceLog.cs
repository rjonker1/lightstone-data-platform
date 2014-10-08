using System;
using System.Diagnostics;
using System.Globalization;
using System.Security;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging
{
    /// <summary>
    ///     Implementation of contract <see cref="ILogger" />
    ///     using System.Diagnostics API.
    /// </summary>
    public sealed class TraceSourceLog : ILogger
    {
        #region Fields

        private readonly TraceSource _source;

        #endregion

        #region  Constructor

        /// <summary>
        ///     Create a new instance of this trace manager
        /// </summary>
        public TraceSourceLog()
        {
            // Create default source
            _source = new TraceSource("TRACER");
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Trace internal message in configured listeners
        /// </summary>
        /// <param name="eventType"> Event type to trace </param>
        /// <param name="message"> Message of event </param>
        private void TraceInternal(TraceEventType eventType, string message)
        {
            if (_source != null)
            {
                try
                {
                    _source.TraceEvent(eventType, (int) eventType, message);
                }
                catch (SecurityException)
                {
                    //Cannot access to file listener or cannot have
                    //privileges to write in event log etc...
                }
            }
        }

        #endregion

        #region ILogger Members

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args">
        ///     <see cref="ILogger" />
        /// </param>
        public void Info(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Information, messageToTrace);
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args">
        ///     <see cref="ILogger" />
        /// </param>
        public void Warning(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Warning, messageToTrace);
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args">
        ///     <see cref="ILogger" />
        /// </param>
        public void Error(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Error, messageToTrace);
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="exception">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args">
        ///     <see cref="ILogger" />
        /// </param>
        public void Error(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message) && exception != null)
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                string exceptionData = exception.ToString();
                // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Error,
                    string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace,
                        exceptionData));
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args">
        ///     <see cref="ILogger" />
        /// </param>
        public void Debug(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Verbose, messageToTrace);
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="exception">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args">
        ///     <see cref="ILogger" />
        /// </param>
        public void Debug(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message) && exception != null)
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                string exceptionData = exception.ToString();
                // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Error,
                    string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="item">
        ///     <see cref="ILogger" />
        /// </param>
        public void Debug(object item)
        {
            if (item != null)
            {
                TraceInternal(TraceEventType.Verbose, item.ToString());
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args">
        ///     <see cref="ILogger" />
        /// </param>
        public void Fatal(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Critical, messageToTrace);
            }
        }

        /// <summary>
        ///     <see cref="ILogger" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="exception">
        ///     <see cref="ILogger" />
        /// </param>
        /// <param name="args"></param>
        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                string messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                string exceptionData = exception.ToString();
                // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Critical,
                    string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        #endregion
    }
}