
namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging
{
    /// <summary>
    ///   Log Factory
    /// </summary>
    public static class LoggerFactory
    {
        #region Fields

        private static ILoggerFactory _currentLogFactory;

        #endregion

        #region Public Methods

        /// <summary>
        ///   Set the  log factory to use
        /// </summary>
        /// <param name="logFactory"> Log factory to use </param>
        public static void SetCurrent(ILoggerFactory logFactory)
        {
            _currentLogFactory = logFactory;
        }

        /// <summary>
        ///   Createt a new <paramref name="Company.Client.Project.CrossCutting.Logging.ILog" />
        /// </summary>
        /// <returns> Created ILog </returns>
        public static ILogger CreateLog()
        {
            return (_currentLogFactory != null) ? _currentLogFactory.Create() : null;
        }

        #endregion
    }
}