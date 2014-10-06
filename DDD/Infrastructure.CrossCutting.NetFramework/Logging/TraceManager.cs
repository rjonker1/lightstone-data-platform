using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Security.Permissions;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Resources;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging
{
    /// <summary>
    ///     Trace helper for application's logging
    /// </summary>
    public sealed class TraceManager
        : ITraceManager
    {
        #region Members

        private readonly TraceSource source;

        #endregion

        #region  Constructor

        /// <summary>
        ///     Create a new instance of this trace manager
        /// </summary>
        public TraceManager()
        {
            // Create default source
            source = new TraceSource("LightstoneApp");
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Trace internal message in configured listeners
        /// </summary>
        /// <param name="eventType">Event type to trace</param>
        /// <param name="message">Message of event</param>
        private void TraceInternal(TraceEventType eventType, string message)
        {
            if (source != null)
            {
                try
                {
                    source.TraceEvent(eventType, (int) eventType, message);
                }
                catch (SecurityException)
                {
                    //Cannot access to file listener or cannot have
                    //privileges to write in event log
                    //do not propagete this :-(
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        /// <param name="operationName">
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </param>
        [SuppressMessage("Microsoft.Security",
            "CA2135:SecurityRuleSetLevel2MethodsShouldNotBeProtectedWithLinkDemandsFxCopRule"),
         SecurityPermission(SecurityAction.LinkDemand)]
        public void TraceStartLogicalOperation(string operationName)
        {
            if (String.IsNullOrEmpty(operationName))
                throw new ArgumentNullException("operationName", Messages.exception_InvalidTraceMessage);

            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            Trace.CorrelationManager.StartLogicalOperation(operationName);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        [SuppressMessage("Microsoft.Security",
            "CA2135:SecurityRuleSetLevel2MethodsShouldNotBeProtectedWithLinkDemandsFxCopRule"),
         SecurityPermission(SecurityAction.LinkDemand)]
        public void TraceStopLogicalOperation()
        {
            try
            {
                Trace.CorrelationManager.StopLogicalOperation();
            }
            catch (InvalidOperationException)
            {
                //stack empty
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        public void TraceStart()
        {
            TraceInternal(TraceEventType.Start, Messages.constant_START);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        public void TraceStop()
        {
            TraceInternal(TraceEventType.Start, Messages.constant_STOP);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </param>
        public void TraceInfo(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Information, message);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </param>
        public void TraceWarning(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Warning, message);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </param>
        public void TraceError(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Error, message);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </summary>
        /// <param name="message">
        ///     <see cref="LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager" />
        /// </param>
        public void TraceCritical(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Critical, message);
        }

        #endregion
    }
}