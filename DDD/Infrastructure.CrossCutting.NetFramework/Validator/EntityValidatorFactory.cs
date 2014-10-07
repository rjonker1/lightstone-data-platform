namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Validator
{
    /// <summary>
    ///   Entity Validator Factory
    /// </summary>
    public static class EntityValidatorFactory
    {
        #region Fields

        private static IEntityValidatorFactory _factory;

        #endregion

        #region Public Methods

        /// <summary>
        ///   Set the  log factory to use
        /// </summary>
        /// <param name="factory"> Log factory to use </param>
        public static void SetCurrent(IEntityValidatorFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        ///   Createt a new <paramref name="Company.Client.Project.CrossCutting.Logging.ILog" />
        /// </summary>
        /// <returns> Created ILog </returns>
        public static IEntityValidator CreateValidator()
        {
            return (_factory != null) ? _factory.Create() : null;
        }

        #endregion
    }
}