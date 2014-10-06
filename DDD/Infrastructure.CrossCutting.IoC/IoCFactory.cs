using LightstoneApp.Infrastructure.CrossCutting.IoC.Unity;

namespace LightstoneApp.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    ///     IoCFactory  implementation
    /// </summary>
    public sealed class IoCFactory
    {
        #region Singleton

        private static readonly IoCFactory instance = new IoCFactory();

        /// <summary>
        ///     Get singleton instance of IoCFactory
        /// </summary>
        public static IoCFactory Instance
        {
            get { return instance; }
        }

        #endregion

        #region Members

        private readonly IContainer _CurrentContainer;

        /// <summary>
        ///     Get current configured IContainer
        ///     <remarks>
        ///         At this moment only IoCUnityContainer existss
        ///     </remarks>
        /// </summary>
        public IContainer CurrentContainer
        {
            get { return _CurrentContainer; }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Only for singleton pattern, remove before field init IL anotation
        /// </summary>
        static IoCFactory()
        {
        }

        private IoCFactory()
        {
            _CurrentContainer = new IoCUnityContainer();
        }

        #endregion
    }
}